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
    public class BookingSeatTokensController : ControllerBase
    {
        private readonly DataContext _context;

        public BookingSeatTokensController(DataContext context)
        {
            _context = context;
        }

        // GET: api/BookingSeatTokens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingSeatToken>>> GetBookingSeatTokens()
        {
            return await _context.BookingSeatTokens.ToListAsync();
        }

        // GET: api/BookingSeatTokens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingSeatToken>> GetBookingSeatToken(int id)
        {
            var bookingSeatToken = await _context.BookingSeatTokens.FindAsync(id);

            if (bookingSeatToken == null)
            {
                return NotFound();
            }

            return bookingSeatToken;
        }

        // PUT: api/BookingSeatTokens/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingSeatToken(int id, BookingSeatToken bookingSeatToken)
        {
            if (id != bookingSeatToken.BookingTokenId)
            {
                return BadRequest();
            }

            _context.Entry(bookingSeatToken).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingSeatTokenExists(id))
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

        // POST: api/BookingSeatTokens
        [HttpPost]
        public async Task<ActionResult<BookingSeatToken>> PostBookingSeatToken(BookingSeatToken bookingSeatToken)
        {
            _context.BookingSeatTokens.Add(bookingSeatToken);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingSeatToken", new { id = bookingSeatToken.BookingTokenId }, bookingSeatToken);
        }

        // DELETE: api/BookingSeatTokens/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookingSeatToken>> DeleteBookingSeatToken(int id)
        {
            var bookingSeatToken = await _context.BookingSeatTokens.FindAsync(id);
            if (bookingSeatToken == null)
            {
                return NotFound();
            }

            _context.BookingSeatTokens.Remove(bookingSeatToken);
            await _context.SaveChangesAsync();

            return bookingSeatToken;
        }

        private bool BookingSeatTokenExists(int id)
        {
            return _context.BookingSeatTokens.Any(e => e.BookingTokenId == id);
        }
    }
}
