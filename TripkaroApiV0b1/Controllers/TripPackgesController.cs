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
    public class TripPackgesController : ControllerBase
    {
        private readonly DataContext _context;

        public TripPackgesController(DataContext context)
        {
            _context = context;
        }
        /// <summary>
        /// GET: api/TripPackges
        /// Method Will Returun All PackageDetails with CurrentTrip Name 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripPackges>>> GetTripPackgess()
        {
            var result = from p in _context.TripPackgess
                         join c in _context.CurrentTrips on p.CurrentTripId equals c.CurrentTripId
                         select new
                         {
                            P_TripPackgesId = p.TripPackgesId,
                             P_PackageName = p.Name,
                             P_PackageQuantity = p.PackageQuantity,
                             P_Description = p.Description,
                             P_EstimatedCost= p.EstimatedCost,
                             P_PackageType = p.PackageType,
                             P_IsSpecialOffer = p.IsSpecialOffer,
                             C_CurrentTripId = c.CurrentTripId,
                             C_TripName = c.TripName,
                         };
            return Ok(result);
            //  return await _context.TripPackgess.ToListAsync();
        }

        /// <summary>
        /// GET: api/TripPackges/5
        /// method Will Return All Package Data Assigning By A specific Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TripPackges>> GetTripPackges(int id)
        {
            var tripPackges = await _context.TripPackgess.FindAsync(id);

            if (tripPackges == null)
            {
                return NotFound();
            }

            return tripPackges;
        }



        /// <summary>
        /// PUT: api/TripPackges/5
        /// This method can update TripPackages But (TripPackgesId,ModifiedBy,ModifiedDate,ModifiedUserId)
        /// Will Automatically Updated
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentTrip"></param>
        /// <returns></returns>
        [Authorize(Roles = Role.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTripPackges(int id, TripPackges tripPackges)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;         // Calling User Data From Users Controller
            var Myusername = claimsIdentity.FindFirst(ClaimTypes.Surname)?.Value;    // Finding Current User
            if (id != tripPackges.TripPackgesId)
            {
                return BadRequest();
            }
            tripPackges.TripPackgesId = id;
            tripPackges.ModifiedUserId = int.Parse(User.Identity.Name);    // Auto Update
            tripPackges.ModifiedBy = Myusername;                    // Auto Update
            tripPackges.ModifiedDate = DateTime.Now;

            _context.Entry(tripPackges).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripPackgesExists(id))
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
        /// POST: api/TripPackges
        /// this Method can Insert Record In TripPackges, The Admin And Organization Role can Add Add Records
        /// Visiter has not permition to Insert Data
        /// </summary>
        /// <param name="currentTrip"></param>
        /// <returns></returns>
        [Authorize(Roles = Role.Admin)]
        [Authorize(Roles = Role.Organization)]
        [HttpPost]
        public async Task<ActionResult<TripPackges>> PostTripPackges(TripPackges tripPackges)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var Myusername = claimsIdentity.FindFirst(ClaimTypes.Surname)?.Value;

            tripPackges.UserId = int.Parse(User.Identity.Name);
            tripPackges.CreatedBy = Myusername;
            tripPackges.CreatedDate = DateTime.Now;
            _context.TripPackgess.Add(tripPackges);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTripPackges", new { id = tripPackges.TripPackgesId }, tripPackges);
        }
        /// <summary>
        /// DELETE: api/TripPackges/5
        /// This is a delete Request. And Only Admin Has the permition to delete from TripPackges data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<TripPackges>> DeleteTripPackges(int id)
        {
            var tripPackges = await _context.TripPackgess.FindAsync(id);
            if (tripPackges == null)
            {
                return NotFound();
            }

            _context.TripPackgess.Remove(tripPackges);
            await _context.SaveChangesAsync();

            
            return Ok(new
            {
                Message = "Record Deleted Sucessfully",
                Data = tripPackges
            });
        }

        private bool TripPackgesExists(int id)
        {
            return _context.TripPackgess.Any(e => e.TripPackgesId == id);
        }
    }
}
