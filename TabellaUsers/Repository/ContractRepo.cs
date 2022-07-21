using Microsoft.EntityFrameworkCore;
using TabellaUsers.DataModel;
using TabellaUsers.Interface;

namespace TabellaUsers.Repository
{
    public class ContractRepo: IContract
    {
        private readonly DataContext _context;

        public ContractRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<ModelContract> CreateContractAsync(ModelContract contract)
        {
            if (_context.Contratto == null)
            {
                return null;
            }
            _context.Contratto.Add(contract);
            await _context.SaveChangesAsync();

            return contract;
        }

        public async Task<ModelContract> DeleteContractAsync(int id)
        {
            if (_context.Contratto == null)
            {
                return null;
            }
            var modelContract = await _context.Contratto.Include(b => b.Users)
                .Where(c => c.IdContract == id).FirstOrDefaultAsync();

            if (modelContract == null)
            {
                return null;
            }

            _context.Contratto.Remove(modelContract);

            await _context.SaveChangesAsync();

            return modelContract;
        }

        public async Task<List<ModelContract>> GetAllContractAsync()
        {
            if (_context.Contratto == null)
            {
                return null;
            }

            return await _context.Contratto.Include(a => a.Users).ThenInclude(c => c.user).ThenInclude(b => b.Azienda).ToListAsync();

        }

        public async Task<List<ModelContract>> GetContract_ID_Async(int id)
        {
            if (_context.Contratto == null)
            {
                return null;
            }
            var modelContract = await _context.Contratto.Include(a => a.Users).ThenInclude(b => b.user).ThenInclude(c => c.Azienda).Where(c => c.IdContract == id).ToListAsync();

            if (modelContract == null)
            {
                return null;
            }

            return modelContract;
        }

        public async Task<ModelContract> UpdateContractAsync(int id, ModelContract modelContract)
        {
            if (id != modelContract.IdContract)
            {
                return null;
            }

            _context.Entry(modelContract).State = EntityState.Modified;

            try
            {
                _context.Contratto.Update(modelContract);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelContractExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return modelContract;
        }

        private bool ModelContractExists(int id)
        {
            return (_context.Contratto?.Any(e => e.IdContract == id)).GetValueOrDefault();
        }
    }
}

