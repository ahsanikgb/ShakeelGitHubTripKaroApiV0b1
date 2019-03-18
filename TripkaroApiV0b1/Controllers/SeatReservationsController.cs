using System;
using System.Collections.Generic;
using System.Linq;
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
    public class SeatReservationsController : ControllerBase
    {
        private readonly DataContext _context;

        public SeatReservationsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/SeatReservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeatReservation>>> GetSeatReservations()
        {
            return await _context.SeatReservations.ToListAsync();
        }

        // GET: api/SeatReservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SeatReservation>> GetSeatReservation(int id)
        {
            var seatReservation = await _context.SeatReservations.FindAsync(id);

            if (seatReservation == null)
            {
                return NotFound();
            }

            return seatReservation;
        }

        // PUT: api/SeatReservations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeatReservation(int id, SeatReservation seatReservation)
        {
            if (id != seatReservation.SeatReservationId)
            {
                return BadRequest();
            }

            _context.Entry(seatReservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeatReservationExists(id))
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

        // POST: api/SeatReservations
        [HttpPost]
        public async Task<ActionResult<SeatReservation>> PostSeatReservation(SeatReservation seatReservation)
        {
            _context.SeatReservations.Add(seatReservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeatReservation", new { id = seatReservation.SeatReservationId }, seatReservation);
        }

        // DELETE: api/SeatReservations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SeatReservation>> DeleteSeatReservation(int id)
        {
            var seatReservation = await _context.SeatReservations.FindAsync(id);
            if (seatReservation == null)
            {
                return NotFound();
            }

            _context.SeatReservations.Remove(seatReservation);
            await _context.SaveChangesAsync();

            return seatReservation;
        }

        private bool SeatReservationExists(int id)
        {
            return _context.SeatReservations.Any(e => e.SeatReservationId == id);
        }
    }
}
