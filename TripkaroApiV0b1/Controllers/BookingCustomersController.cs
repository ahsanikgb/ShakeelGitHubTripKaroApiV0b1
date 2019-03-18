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
    public class BookingCustomersController : ControllerBase
    {
        private readonly DataContext _context;

        public BookingCustomersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/BookingCustomers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingCustomer>>> GetBookingCustomers()
        {
            return await _context.BookingCustomers.ToListAsync();
        }

        // GET: api/BookingCustomers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingCustomer>> GetBookingCustomer(int id)
        {
            var bookingCustomer = await _context.BookingCustomers.FindAsync(id);

            if (bookingCustomer == null)
            {
                return NotFound();
            }

            return bookingCustomer;
        }

        // PUT: api/BookingCustomers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingCustomer(int id, BookingCustomer bookingCustomer)
        {
            if (id != bookingCustomer.BookingCustomerId)
            {
                return BadRequest();
            }

            _context.Entry(bookingCustomer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingCustomerExists(id))
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

        // POST: api/BookingCustomers
        [HttpPost]
        public async Task<ActionResult<BookingCustomer>> PostBookingCustomer(BookingCustomer bookingCustomer)
        {
            _context.BookingCustomers.Add(bookingCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingCustomer", new { id = bookingCustomer.BookingCustomerId }, bookingCustomer);
        }

        // DELETE: api/BookingCustomers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookingCustomer>> DeleteBookingCustomer(int id)
        {
            var bookingCustomer = await _context.BookingCustomers.FindAsync(id);
            if (bookingCustomer == null)
            {
                return NotFound();
            }

            _context.BookingCustomers.Remove(bookingCustomer);
            await _context.SaveChangesAsync();

            return bookingCustomer;
        }

        private bool BookingCustomerExists(int id)
        {
            return _context.BookingCustomers.Any(e => e.BookingCustomerId == id);
        }
    }
}
