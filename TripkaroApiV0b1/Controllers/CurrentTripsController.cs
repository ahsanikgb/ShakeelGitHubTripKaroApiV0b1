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
    public class CurrentTripsController : ControllerBase
    {
        private readonly DataContext _context;


        public CurrentTripsController(DataContext context)
        {
            _context = context;

        }

        /// <summary>
        /// GET: api/CurrentTrips
        /// This Method Will Fetch All Three table Attributes By Joining
        /// CurrentTrip,VisitingPlacess,TripPackges Table
        /// To Get Record We Need To Update TripPackges And Visiting Placess By Adding CurrentTripId Column
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrentTrip>>> GetCurrentTrips()
        {
            // var result = from CurrentTrip in _context.CurrentTrips
            //    join TripVisitingPlaces in _context.TripVisitingPlacess on CurrentTrip.CurrentTripId equals TripVisitingPlaces.CurrentTripId
            var result= from c in _context.CurrentTrips
                        join v in _context.TripVisitingPlacess on c.CurrentTripId equals v.CurrentTripId
                        join p in _context.TripPackgess on c.CurrentTripId equals p.CurrentTripId


            select new
                         {
                             TCurrentTripId = c.CurrentTripId,
                             TTripName = c.TripName,
                             TStartingLocation = c.StartingLocation,
                             TTotalBudget = c.TotalBudget,
                             TDescount = c.Descount,
                             TTripDuration = c.TripDuration,
                             TAdvisorsContact1 = c.AdvisorsContact1,
                             TAdvisorsContact2 = c.AdvisorsContact2,
                             TDateOfArival = c.DateOfArival,
                             TDateOfDeparture = c.DateOfDeparture,
                             TTotalSeats = c.TotalSeats,
                             TRemainingSeats = c.RemainingSeats,
                             VPlaceName = v.PlaceName,
                             VstayingHours = v.stayingHours,
                             VNearestLocations = v.NearestLocations,
                             PPackageName = p.Name,
                             PEachPackageCost = p.EstimatedCost,
                             PSpecialOffer = p.IsSpecialOffer,
                             PQuantity = p.PackageQuantity,
                             PDescription = p.Description,             
            };
            return Ok(result);

            // return await _context.CurrentTrips.ToListAsync();
        }

        /// <summary>
        /// GET: api/TestCurrentTrips/5
        /// this method will return only Current Trip Data By assigning Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CurrentTrip>> GetCurrentTrip(int id)
        {

            var currentTrip = await _context.CurrentTrips.FindAsync(id);

            if (currentTrip == null)
            {
                return NotFound();
            }

            return currentTrip;
        }

        /// <summary>
        /// PUT: api/TestCurrentTrips/5
        /// This method can update Current Trip But (CurrentTripId,ModifiedBy,ModifiedDate,ModifiedUserId)
        /// Will Automatically Updated
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentTrip"></param>
        /// <returns></returns>
        [Authorize(Roles = Role.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurrentTrip(int id, CurrentTrip currentTrip)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;         // Calling User Data From Users Controller
            var Myusername = claimsIdentity.FindFirst(ClaimTypes.Surname)?.Value;    // Finding Current User
    //      var mycurrentTrip = await _context.CurrentTrips.FindAsync(id);      // finding  Db Values

            if (id != currentTrip.CurrentTripId)
            {
                return BadRequest();
            }
            //         currentTrip = mycurrentTrip;                // Assigning Values To Current Model
            currentTrip.CurrentTripId = id;
            currentTrip.ModifiedUserId = int.Parse(User.Identity.Name);    // Auto Update
            currentTrip.ModifiedBy = Myusername;                    // Auto Update
            currentTrip.ModifiedDate = DateTime.Now;                // Auto Update



            _context.Entry(currentTrip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrentTripExists(id))
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
        /// POST: api/TestCurrentTrips
        /// this Method can Insert Record In CurrentTrip, The Admin And Organization Role can Add Add Records
        /// Visiter has not permition to Insert Data
        /// </summary>
        /// <param name="currentTrip"></param>
        /// <returns></returns>
        [Authorize(Roles = Role.Admin)]
        [Authorize(Roles = Role.Organization)]
        [HttpPost]
        public async Task<ActionResult<CurrentTrip>> PostCurrentTrip(CurrentTrip currentTrip)
        {

            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var Myusername = claimsIdentity.FindFirst(ClaimTypes.Surname)?.Value;


            currentTrip.UserId =int.Parse(User.Identity.Name);
            currentTrip.CreatedBy = Myusername;
            currentTrip.CreatedDate=DateTime.Now;
            

            _context.CurrentTrips.Add(currentTrip);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurrentTrip", new { id = currentTrip.CurrentTripId }, currentTrip);
        }

        /// <summary>
        /// DELETE: api/TestCurrentTrips/5
        /// This is a delete Request. And Only Admin Has the permition to delete from currentTrip data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<CurrentTrip>> DeleteCurrentTrip(int id)
        {
            var currentTrip = await _context.CurrentTrips.FindAsync(id);
            if (currentTrip == null)
            {
                return NotFound();
            }

            _context.CurrentTrips.Remove(currentTrip);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message="Record Deleted Sucessfully",
                Data = currentTrip
            });
        }
        private bool CurrentTripExists(int id)
        {

            return _context.CurrentTrips.Any(e => e.CurrentTripId == id);
        }
    }
}
