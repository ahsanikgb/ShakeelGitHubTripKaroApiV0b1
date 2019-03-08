using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripkaroApiV0b1.Helpers;
using TripkaroApiV0b1.MyDbContext;
using TripkaroApiV0b1.Services;

namespace TripkaroApiV0b1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAdministrationController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUserService _userService;

        public UserAdministrationController(DataContext context)
        {
            _context = context;
        }
       

        // GET: api/Administration
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Administration/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User usr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }



            _context.Users.Add(new User()
            {

                FirstName = usr.FirstName,
                LastName = usr.LastName,
                Username = usr.Username,
                PasswordHash = usr.PasswordHash,
                });
            if (usr.Role == Role.Admin || usr.Role == Role.Tourest || usr.Role == Role.Organization)
            {
                _context.Add(usr.Role);
            }
            else {
                return BadRequest(new { message = "Role is incorrect" });
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = usr.Id }, usr);

        }

        // PUT: api/Administration/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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



        // DELETE: api/Administration/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
