using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TabellaUsers.DataModel;
using TabellaUsers.Interface;

namespace TabellaUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PivotController : ControllerBase 
    {
        private readonly IPivot _pivot;

        public PivotController(IPivot pivot)
        {
            _pivot = pivot;
        }

        // GET: api/Pivot
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PivotUserContract>>> GetContractUsersPivot()
        {
            return await _pivot.GetPivotDataAsync();           
        }

        // GET: api/Pivot/5
        [HttpGet("{userID}/{contractID}")]
        public async Task<ActionResult<PivotUserContract>> GetPivotUserContract(int userID, int contractID)
        {
            return await _pivot.GetSinglePivotData(userID, contractID);
        }

        // POST: api/Pivot
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PivotUserContract>> PostPivotUserContract(PivotUserContract pivotUserContract)
        {
            return await _pivot.CreatePivotData(pivotUserContract);
        }

        // DELETE: api/Pivot/5
        [HttpDelete("{userID}/{contractID}")]
        public async Task<HttpResponseMessage> DeletePivotUserContract(int userID, int contractID)
        {
            return await _pivot.DeletePivotData(userID, contractID);
        }


    }
}
