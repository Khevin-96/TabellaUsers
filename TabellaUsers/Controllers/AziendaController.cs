using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TabellaUsers.DataModel;

namespace TabellaUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AziendaController : ControllerBase
    {
        private readonly DataContext _context;

        public AziendaController(DataContext context)
        {
            _context = context;
        }

        public Expression<Func<ModelAzienda, object>> Users { get; private set; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelAzienda>>> GetAzienda()
        {
            if (_context.Azienda == null)
            {
                return NotFound();
            }
            return await _context.Azienda.Include(a=>a.Users).ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<ModelAzienda>>> GetModelAzienda(int id)
        {
            if (_context.Azienda == null)
            {
                return NotFound();
            }

            // var modelAzienda = await _context.Azienda.FindAsync(id);
             var modelAzienda = await _context.Azienda.Include(a => a.Users.Where(b=>b.Azienda_Id==id)).ToListAsync();

           // var modelAzienda = await _context.Azienda.Include(a => a.Users).FirstAsync(id);
            if (modelAzienda == null)
            {
                return NotFound();
            }

            return modelAzienda;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelAzienda(int id, ModelAzienda modelAzienda)
        {
            if (id!=modelAzienda.IdAzienda)
            {
                return BadRequest();
            }

            _context.Entry(modelAzienda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelAziendaExist(id))
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
        public async Task<ActionResult<ModelAzienda>> PostModelAzienda(ModelAzienda modelazienda)
        {
            
            if (_context.Azienda == null)
            {
                return Problem("Entity set 'DataContext.Azienda'  is null.");
            }
            _context.Azienda.Add(modelazienda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModelAzienda", new { id = modelazienda.IdAzienda }, modelazienda);
        }


        [HttpDelete("id")]
        public async Task<IActionResult> DeleteModelAzienda(int id)
        {
            if (_context.Azienda == null)
            {
                return NotFound();
            }

            var modelAzienda = await _context.Azienda.FindAsync(id);
            if (modelAzienda==null)
            {
                return NotFound();
            }
            _context.Azienda.Remove(modelAzienda);
            await _context.SaveChangesAsync();
            return NoContent();
        }



        private bool ModelAziendaExist(int id)
        {
            return (_context.Azienda?.Any(a => a.IdAzienda == id)).GetValueOrDefault();
        }
    }
}
