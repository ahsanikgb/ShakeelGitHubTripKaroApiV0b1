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
    public class UserSelfPackgesController : ControllerBase
    {
        private readonly DataContext _context;

        public UserSelfPackgesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/UserSelfPackges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserSelfPackges>>> GetUserSelfPackgess()
        {
            return await _context.UserSelfPackgess.ToListAsync();
        }

        // GET: api/UserSelfPackges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserSelfPackges>> GetUserSelfPackges(int id)
        {
            var userSelfPackges = await _context.UserSelfPackgess.FindAsync(id);

            if (userSelfPackges == null)
            {
                return NotFound();
            }

            return userSelfPackges;
        }
        /// <summary>
        /// // PUT: api/UserSelfPackges/5
        /// Admin Has The Permition To Update Records Into this Method
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userSelfPackges"></param>
        /// <returns></returns>
        [Authorize(Roles = Role.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserSelfPackges(int id, UserSelfPackges userSelfPackges)
        {
            if (id != userSelfPackges.UserSelfPackgesId)
            {
                return BadRequest();
            }

            _context.Entry(userSelfPackges).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSelfPackgesExists(id))
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
        ///  POST: api/UserSelfPackges
        ///  Everyone  have  The Permition To Add Some Records Into SelfPackges Controller
        /// </summary>
        /// <param name="userSelfPackges"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<UserSelfPackges>> PostUserSelfPackges(int TripPackgesId,UserSelfPackges userSelfPackges)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var Myusername = claimsIdentity.FindFirst(ClaimTypes.Surname)?.Value;
            if (_context.TripPackgess.Any(V => V.TripPackgesId != TripPackgesId))         // Getting Value From Database and Check IsEqual
            {
                return BadRequest(new { message = "Please Enter A Valid Trip_Packges_Id" });
            }
            else
            {
                userSelfPackges.UserId = int.Parse(User.Identity.Name);
                userSelfPackges.CreatedBy = Myusername;
                userSelfPackges.CreatedDate = DateTime.Now;
                userSelfPackges.UserPackgesId=TripPackgesId;

                _context.UserSelfPackgess.Add(userSelfPackges);
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserSelfPackges", new { id = userSelfPackges.UserSelfPackgesId }, userSelfPackges);
        }

        /// <summary>
        /// DELETE: api/UserSelfPackges/5
        /// Only Admin  Has the Permition To Delete Self Packges
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserSelfPackges>> DeleteUserSelfPackges(int id)
        {
            var userSelfPackges = await _context.UserSelfPackgess.FindAsync(id);
            if (userSelfPackges == null)
            {
                return NotFound();
            }

            _context.UserSelfPackgess.Remove(userSelfPackges);
            await _context.SaveChangesAsync();           
            return Ok(new
            {
                Message = "Record Deleted Sucessfully",
                Data = userSelfPackges
            });
        }

        private bool UserSelfPackgesExists(int id)
        {
            return _context.UserSelfPackgess.Any(e => e.UserSelfPackgesId == id);
        }
    }
}
