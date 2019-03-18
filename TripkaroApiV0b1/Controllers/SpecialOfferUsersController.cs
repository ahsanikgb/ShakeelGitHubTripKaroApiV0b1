using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripkaroApiV0b1.Helpers;
using TripkaroApiV0b1.MyDbContext;

namespace TripkaroApiV0b1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOfferUsersController : ControllerBase
    {
        private readonly DataContext _context;

        public SpecialOfferUsersController(DataContext context)
        {
            _context = context;
        }


        /// <summary>
        /// GET: api/SpecialOfferUsers
        /// This Method Will Fetch All Three table Attributes By Joining
        /// SpecialOffer,SpecialOfferUsers,Users Table
        /// This Is Only For Admin Role, Admin Can See All Subscribed Users Data
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecialOfferUsers>>> GetSpecialOfferUserss()
        {
            var result = from su in _context.SpecialOfferUserss
                         join s in _context.SpecialOffers on su.SpecialOfferId equals s.SpecialOfferId
                         join u in _context.Users on su.UserId equals u.Id


                         select new
                         {
                             Su_SpecialOfferUserId = su.SpecialOfferUserId,
                             Su_SpecialOfferUserName = su.SpecialOfferUserName,
                             TCurrentTripId = su.OfferVoutureCode,
                             Su_SpecialOfferId = su.SpecialOfferId,
                             Su_UserId = su.UserId,
                             S_SpecialOfferName = s.SpecialOfferName,
                             S_DealCode = s.DealCode,
                             S_Descount = s.Descount,
                             S_Description = s.Description,
                             U_Username = u.Username,
                             U_Role = u.Role,
                         };
            return Ok(result);
            //  return await _context.SpecialOfferUserss.ToListAsync();
        }

        /// <summary>
        /// GET: api/SpecialOfferUsers/5
        /// this method will return only SpecialOfferUsers  Data By assigning it to a specific Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<SpecialOfferUsers>> GetSpecialOfferUsers(int id)
        {
            var specialOfferUsers = await _context.SpecialOfferUserss.FindAsync(id);

            if (specialOfferUsers == null)
            {
                return NotFound();
            }

            return specialOfferUsers;
        }


        /// <summary>
        /// PUT: api/SpecialOfferUsers/5
        /// This method can update SpecialOfferUsers But (SpecialOfferUserId,ModifiedBy,ModifiedDate,ModifiedUserId)
        /// Will Automatically Updated
        /// This Is For Visiter They Want to Modify Special Offer They Need To Pass to Peramerter First Is "Id" And The Second is "VoutureCode"
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentTrip"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecialOfferUsers(int id,string VoutureCode, SpecialOfferUsers specialOfferUsers)
        {

            var claimsIdentity = this.User.Identity as ClaimsIdentity;         // Calling User Data From Users Controller
            var Myusername = claimsIdentity.FindFirst(ClaimTypes.Surname)?.Value;    // Finding Current User
            if (id != specialOfferUsers.SpecialOfferUserId)
            {
                return BadRequest();
            }
            specialOfferUsers.SpecialOfferUserId = id;
            specialOfferUsers.ModifiedUserId = int.Parse(User.Identity.Name);    // Auto Update
            specialOfferUsers.ModifiedBy = Myusername;                    // Auto Update
            specialOfferUsers.ModifiedDate = DateTime.Now;                // Auto Update
            specialOfferUsers.SpecialOfferUserName = Myusername;

            if (_context.SpecialOfferUserss.Any(V => V.OfferVoutureCode != VoutureCode))         // Getting Value From Database and Check IsEqual
            {
                return BadRequest(new { message = "Your Vouture Code Is Invalid Please Enter Valid Vouture Code" });
            }
            else
            {
                Guid g = Guid.NewGuid();
                string GuidString = Convert.ToBase64String(g.ToByteArray());
                GuidString = GuidString.Replace("=", "");
                GuidString = GuidString.Replace("+", "");
                specialOfferUsers.OfferVoutureCode = GuidString;

                _context.Entry(specialOfferUsers).State = EntityState.Modified;
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialOfferUsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SpecialOfferUsers

        /// <summary>
        /// POST: api/SpecialOfferUsers
        /// this Method can Insert Record In SpecialOfferUsers, This Is For Visters To Subscribed Any Deal.
        /// if the Deals limit Exceed 2 It will return Bad Request and If the Subscription Limit Is Less then 2 it will allow you to subscribed
        /// note: UserId,CreatedBy and Created Date automatically updated the method will return vouture code letter on user can get descount if the vouture code is valid
        /// Visiter has not permition to Insert Data
        /// </summary>
        /// <param name="currentTrip"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<SpecialOfferUsers>> PostSpecialOfferUsers(SpecialOfferUsers specialOfferUsers)
        {

            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var Myusername = claimsIdentity.FindFirst(ClaimTypes.Surname)?.Value;

            

            specialOfferUsers.UserId = int.Parse(User.Identity.Name);
            specialOfferUsers.CreatedBy = Myusername;
            specialOfferUsers.SpecialOfferUserName = Myusername;
            specialOfferUsers.CreatedDate = DateTime.Now;

            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            specialOfferUsers.OfferVoutureCode = GuidString;

            var MaximumSubscribedUsers = _context.SpecialOfferUserss.Count(i => i.UserId >0);
            if (MaximumSubscribedUsers >= 3)
            {
                return BadRequest(new { message = "Only 2 Subscriptions Are Allowed.You Need to Unsubscribed Earler Subscriptions" });
            }
            else
            {

                _context.SpecialOfferUserss.Add(specialOfferUsers);
                await _context.SaveChangesAsync();
            }

            //   return CreatedAtAction("GetSpecialOfferUsers", new { id = specialOfferUsers.SpecialOfferUserId }, specialOfferUsers);
            return Ok(new
            {
                Message = "COngrats"+ Myusername+ "You have Subscribed" + specialOfferUsers+ "Your VoutureCode Is" + specialOfferUsers.OfferVoutureCode + "You Got Descount Regarding To your VoutureCode",
                Id = specialOfferUsers.SpecialOfferUserId,
                OfferVoutureCode = specialOfferUsers.OfferVoutureCode,
                specialOfferUsers
            });
        }
        /// <summary>
        /// DELETE: api/SpecialOfferUsers/5
        /// This is a delete Request. And Only Admin Has the permition to delete from SpecialOfferUsers data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<SpecialOfferUsers>> DeleteSpecialOfferUsers(int id)
        {
            var specialOfferUsers = await _context.SpecialOfferUserss.FindAsync(id);
            if (specialOfferUsers == null)
            {
                return NotFound();
            }

            _context.SpecialOfferUserss.Remove(specialOfferUsers);
            await _context.SaveChangesAsync();

            // return specialOfferUsers;
            return Ok(new
            {
                Message = "Record Deleted Sucessfully",
                Data = specialOfferUsers
            });
        }

        private bool SpecialOfferUsersExists(int id)
        {
            return _context.SpecialOfferUserss.Any(e => e.SpecialOfferUserId == id);
        }

        private bool UserIdExistOrNot(int id)
        {
            return _context.SpecialOfferUserss.Any(e => e.UserId == id);
        }
    }
}
