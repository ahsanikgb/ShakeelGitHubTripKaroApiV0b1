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
    public class SpecialOffersController : ControllerBase
    {
        private readonly DataContext _context;

        public SpecialOffersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/SpecialOffers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecialOffer>>> GetSpecialOffers()
        {
            return await _context.SpecialOffers.ToListAsync();
        }

        // GET: api/SpecialOffers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpecialOffer>> GetSpecialOffer(int id)
        {
            var specialOffer = await _context.SpecialOffers.FindAsync(id);

            if (specialOffer == null)
            {
                return NotFound();
            }

            return specialOffer;
        }
        /// <summary>
        /// PUT: api/SpecialOffers/5
        /// This method can update SpecialOffers But (SpecialOfferSId,ModifiedBy,ModifiedDate,ModifiedUserId)
        /// Will Automatically Updated
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentTrip"></param>
        /// <returns></returns>
        [Authorize(Roles = Role.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecialOffer(int id, SpecialOffer specialOffer)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;         // Calling User Data From Users Controller
            var Myusername = claimsIdentity.FindFirst(ClaimTypes.Surname)?.Value;    // Finding Current User
            if (id != specialOffer.SpecialOfferId)
            {
                return BadRequest();
            }
            specialOffer.SpecialOfferId = id;
            specialOffer.ModifiedUserId = int.Parse(User.Identity.Name);    // Auto Update
            specialOffer.ModifiedBy = Myusername;                    // Auto Update
            specialOffer.ModifiedDate = DateTime.Now;                // Auto Update

            _context.Entry(specialOffer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialOfferExists(id))
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



        /// <summary>
        ///  POST: api/SpecialOffers
        /// this Method can Insert Record In SpecialOffers, The Admin And Organization Role can Insert Records
        /// Visiter has not permition to Insert Data
        /// </summary>
        /// <param name="currentTrip"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin, Organization")]
        [HttpPost]
        public async Task<ActionResult<SpecialOffer>> PostSpecialOffer(SpecialOffer specialOffer)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var Myusername = claimsIdentity.FindFirst(ClaimTypes.Surname)?.Value;

            specialOffer.UserId = int.Parse(User.Identity.Name);
            specialOffer.CreatedBy = Myusername;
            specialOffer.CreatedDate = DateTime.Now;

            _context.SpecialOffers.Add(specialOffer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpecialOffer", new { id = specialOffer.SpecialOfferId }, specialOffer);
        }


        /// <summary>
        /// DELETE: api/SpecialOffers/5
        /// This is a delete Request. And Only Admin Has the permition to delete from SpecialOffers data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<SpecialOffer>> DeleteSpecialOffer(int id)
        {
            var specialOffer = await _context.SpecialOffers.FindAsync(id);
            if (specialOffer == null)
            {
                return NotFound();
            }

            _context.SpecialOffers.Remove(specialOffer);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                Message = "Record Deleted Sucessfully",
                Data = specialOffer
            });
        }

        private bool SpecialOfferExists(int id)
        {
            return _context.SpecialOffers.Any(e => e.SpecialOfferId == id);
        }
    }
}
