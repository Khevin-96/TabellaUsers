using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text;
using System.Web.Http;
using TabellaUsers.DataModel;
using TabellaUsers.Interface;

namespace TabellaUsers.Repository
{
    public class PivotRepo : IPivot
    {
        private readonly DataContext _context;

        public PivotRepo(DataContext context)
        {
            _context = context;
        }
        public async Task<PivotUserContract> CreatePivotData(PivotUserContract pivotUserContract)
        {
            if (_context.ContractUsersPivot == null)
            {
                return null;
            }
            _context.ContractUsersPivot.Add(pivotUserContract);
            await _context.SaveChangesAsync();

            return pivotUserContract;
        }

        public async Task<HttpResponseMessage> DeletePivotData(int userID, int contractID)
        {
            if (_context.ContractUsersPivot == null)
            {
                return null;
            }
            var modelPivot = await _context.ContractUsersPivot.Where(c => c.User_id == userID && c.Contract_id == contractID).FirstOrDefaultAsync();
            if(modelPivot == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _context.ContractUsersPivot.Remove(modelPivot);
            await _context.SaveChangesAsync();
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.Accepted;
            response.Content = new StringContent("Cancellazione effettuata", Encoding.Unicode);
            return response;

        }

        public async Task<List<PivotUserContract>> GetPivotDataAsync()
        {
            if (_context.ContractUsersPivot == null)
            {
                return null;
            }

            return await _context.ContractUsersPivot.Include(a => a.user).Include(a => a.contract).ToListAsync();
        }

        public async Task<PivotUserContract> GetSinglePivotData(int userID, int contractID)
        {
            if (_context.ContractUsersPivot == null)
            {
                return null;
            }
            return await _context.ContractUsersPivot.Where(up => up.User_id == userID && up.Contract_id == contractID).Include(u => u.user).Include(u => u.contract).FirstOrDefaultAsync();
        }
    }
}
