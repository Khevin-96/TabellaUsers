using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TabellaUsers.DataModel;

namespace TabellaUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly DataContext _context;

        public ContractController(DataContext context)
        {
            _context = context;
        }

        public Expression<Func<ModelContract, object>> Users { get; private set; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelContract>>> GetContract()
        {
            if (_context.Azienda == null)
            {
                return NotFound();
            }
            return await _context.Contratto.Include(b => b.Users).ThenInclude(c => c.user).ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ModelContract>> GetModelContract(int id)
        {
            if (_context.Azienda == null)
            {
                return NotFound();
            }
            var modelContract = await _context.Contratto.FindAsync(id);

            if (modelContract == null)
            {
                return NotFound();
            }

            return modelContract;
        }


        [HttpPut("id")]
        public async Task<IActionResult> PutModelContract(int id, ModelContract modelContract)
        {
            if (id!=modelContract.IdContract)
            {
                return BadRequest();
            }

            _context.Entry(modelContract).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                if (!ModelContractExist(id))
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


        [HttpPost]
        public async Task<ActionResult<ModelContract>> PostModelContract(ModelContract modelcontract)
        {
            if (_context.Contratto==null)
            {
                return Problem("Entity set 'DataContext.Users' is null.");
            }

            _context.Contratto.Add(modelcontract);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModelContract", new { id = modelcontract.IdContract }, modelcontract);

        }


        [HttpDelete("id")]
        public async Task<IActionResult> DeleteModelContract(int id)
        {
            if (_context.Contratto==null)
            {
                return NotFound();
            }

            var modelContract = await _context.Contratto.FindAsync(id);
            if (modelContract==null)
            {
                return NotFound();
            }
            _context.Contratto.Remove(modelContract);
            await _context.SaveChangesAsync();

            return NoContent();
            
        }


        private bool ModelContractExist(int id)
        {
            return (_context.Contratto?.Any(e => e.IdContract == id)).GetValueOrDefault();
        }
    }
}
