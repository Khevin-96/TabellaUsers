using Microsoft.EntityFrameworkCore;
using TabellaUsers.DataModel;
using TabellaUsers.Interface;

namespace TabellaUsers.Repository
{
    public class AziendaRepo : IAzienda
    {
        private readonly DataContext _context;

        public AziendaRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<ModelAzienda> CreateAziendaAsync(ModelAzienda azienda)
        {
            if (azienda.NameAzienda==null)
            {
                return null;
            }
            _context.Azienda.Add(azienda);
            await _context.SaveChangesAsync();

            return azienda;
        }


        public async Task<ModelAzienda> DeleteAziendaAsync(int id)
        {
            if (_context.Azienda == null)
            {
                return null;
            }
            var modelAzienda = await _context.Azienda.Where(u => u.IdAzienda == id).FirstOrDefaultAsync();
 
            if (modelAzienda == null)
            {
                return null;
            }

            _context.Azienda.Remove(modelAzienda);


            await _context.SaveChangesAsync();

            return modelAzienda;
        }



        public async Task<List<ModelAzienda>> GetAllAziendaAsync()
        {
            if (_context.Azienda == null)
            {
                return null;
            }

            return await _context.Azienda.Include(a => a.Users).ToListAsync();
        }


        public async Task<List<ModelAzienda>> GetAzienda_ID_Async(int id)
        {
            if (_context.Azienda == null)
            {
                return null;
            }
            var modelAzienda = await _context.Azienda.Include(a => a.Users).ThenInclude(c => c.Contracts).Where(c => c.IdAzienda == id).ToListAsync();

            return modelAzienda;
        }



        public async Task<ModelAzienda> UpdateAziendaAsync(int id, ModelAzienda modelAzienda)
        {
            if (id != modelAzienda.IdAzienda)
            {
                return null;
            }

            _context.Entry(modelAzienda).State = EntityState.Modified;

            try
            {
                _context.Azienda.Update(modelAzienda);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelAziendaExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return modelAzienda;
        }


        private bool ModelAziendaExists(int id)
        {
            return (_context.Azienda?.Any(e => e.IdAzienda == id)).GetValueOrDefault();
        }
    }
}
