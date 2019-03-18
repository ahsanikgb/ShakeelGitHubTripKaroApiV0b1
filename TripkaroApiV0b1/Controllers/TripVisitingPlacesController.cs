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
    public class TripVisitingPlacesController : ControllerBase
    {
        private readonly DataContext _context;

        public TripVisitingPlacesController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        ///GET: api/TripVisitingPlaces
        /// This method will Return Visiting Placess data And Current Trip name By Its Id
        /// Join used Between VisitingPlacess and CurrentTrip To retrive CurrentTrip Name
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripVisitingPlaces>>> GetTripVisitingPlacess()
        {
            var result = from v in _context.TripVisitingPlacess
                         join c in _context.CurrentTrips on v.CurrentTripId equals c.CurrentTripId                      
                         select new
                         {
                             VvisitingPlacessId = v.TripVisitingPlacesid,
                             VPlaceName= v.PlaceName,
                             VCurrentTripId = v.CurrentTripId,
                             CTripName= c.TripName,
                             VDescription= v.Description,
                             VNearestLocation = v.NearestLocations,
                             VStyingHours = v.stayingHours,
                         };
            return  Ok(result);
            //return await _context.TripVisitingPlacess.ToListAsync();
        }

        /// <summary>
        /// GET: api/TripVisitingPlaces/5
        /// This Method Will Return Only Visting Placess data By Its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TripVisitingPlaces>> GetTripVisitingPlaces(int id)
        {
            var tripVisitingPlaces = await _context.TripVisitingPlacess.FindAsync(id);
            if (tripVisitingPlaces == null)
            {
                return NotFound();
            }

            return tripVisitingPlaces;
        }

        /// <summary>
        /// PUT: api/TripVisitingPlaces/5
        /// This method can update TripVisitingPlacess But (TripVisitingPlacesid,ModifiedBy,ModifiedDate,ModifiedUserId)
        /// Will Automatically Updated
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tripVisitingPlaces"></param>
        /// <returns></returns>
        [Authorize(Roles = Role.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTripVisitingPlaces(int id, TripVisitingPlaces tripVisitingPlaces)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;         // Calling User Data From Users Controller
            var Myusername = claimsIdentity.FindFirst(ClaimTypes.Surname)?.Value;    // Finding Current User
            var mycurrentTrip = await _context.CurrentTrips.FindAsync(id);
            if (id != tripVisitingPlaces.TripVisitingPlacesid)
            {
                return BadRequest();
            }
            tripVisitingPlaces.TripVisitingPlacesid = id;
            tripVisitingPlaces.ModifiedUserId = int.Parse(User.Identity.Name);    // Auto Update
            tripVisitingPlaces.ModifiedBy = Myusername;                    // Auto Update
            tripVisitingPlaces.ModifiedDate = DateTime.Now;                // Auto Update

            _context.Entry(tripVisitingPlaces).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripVisitingPlacesExists(id))
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
        /// POST: api/TripVisitingPlaces
        /// </summary>
        /// <param name="tripVisitingPlaces"></param>
        /// <returns></returns>
        [Authorize(Roles = Role.Admin)]
        [Authorize(Roles = Role.Organization)]
        [HttpPost]
        public async Task<ActionResult<TripVisitingPlaces>> PostTripVisitingPlaces(TripVisitingPlaces tripVisitingPlaces)
        {

            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            var Myusername = claimsIdentity.FindFirst(ClaimTypes.Surname)?.Value;


            tripVisitingPlaces.UserId = int.Parse(userId);
            tripVisitingPlaces.CreatedBy = Myusername;
            tripVisitingPlaces.CreatedDate = DateTime.Now;


            _context.TripVisitingPlacess.Add(tripVisitingPlaces);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTripVisitingPlaces", new { id = tripVisitingPlaces.TripVisitingPlacesid }, tripVisitingPlaces);
        }

        // DELETE: api/TripVisitingPlaces/5
        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<TripVisitingPlaces>> DeleteTripVisitingPlaces(int id)
        {
            var tripVisitingPlaces = await _context.TripVisitingPlacess.FindAsync(id);
            if (tripVisitingPlaces == null)
            {
                return NotFound();
            }

            _context.TripVisitingPlacess.Remove(tripVisitingPlaces);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "Record Deleted Sucessfully",
                Data = tripVisitingPlaces
            });
        }

        private bool TripVisitingPlacesExists(int id)
        {
            return _context.TripVisitingPlacess.Any(e => e.TripVisitingPlacesid == id);
        }
    }
}
