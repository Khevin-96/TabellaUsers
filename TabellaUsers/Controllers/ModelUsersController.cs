using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TabellaUsers.DataModel;


namespace TabellaUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelUsersController : ControllerBase
    {
        private readonly DataContext _context;

        public ModelUsersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ModelUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelUsers>>> GetUsers()
        {
          
          if (_context.Users == null)
          {

              return NotFound();
          }

            return await _context.Users.Include(a=>a.Contracts).ThenInclude(c=>c.contract).Include(b=>b.Azienda).ToListAsync();
        }

        // GET: api/ModelUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModelUsers>> GetModelUsers(int id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var modelUsers = await _context.Users.FindAsync(id);

            if (modelUsers == null)
            {
                return NotFound();
            }

            return modelUsers;
        }

        // PUT: api/ModelUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelUsers(int id, ModelUsers modelUsers)
        {
            if (id != modelUsers.UserId)
            {
                return BadRequest();
            }

            _context.Entry(modelUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelUsersExists(id))
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

        // POST: api/ModelUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ModelUsers>> PostModelUsers(ModelUsers modelUsers)
        {
          if (_context.Users == null)
          {
              return Problem("Entity set 'DataContext.Users'  is null.");
          }
            _context.Users.Add(modelUsers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModelUsers", new { id = modelUsers.UserId }, modelUsers);
        }

        // DELETE: api/ModelUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelUsers(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var modelUsers = await _context.Users.FindAsync(id);
            if (modelUsers == null)
            {
                return NotFound();
            }

            _context.Users.Remove(modelUsers);
            
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        private bool ModelUsersExists(int id)
        {
            return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
