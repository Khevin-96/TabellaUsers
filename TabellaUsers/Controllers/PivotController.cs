using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TabellaUsers.DataModel;
using TabellaUsers.Interface;
using CoreApiResponse;

namespace TabellaUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PivotController : BaseController 
    {
        private readonly IPivot _pivot;

        public PivotController(IPivot pivot)
        {
            _pivot = pivot;
        }

        // GET: api/Pivot
        [HttpGet]
        public async Task<IActionResult> GetContractUsersPivot()
        {
            try
            {
                var pivot = await _pivot.GetPivotDataAsync();
                if (pivot == null)
                {
                    return CustomResult("Utenti non trovati", HttpStatusCode.NotFound);
                }
                return CustomResult("Utenti Caricati", pivot);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Pivot/5
        [HttpGet("{userID}/{contractID}")]
        public async Task<IActionResult> GetPivotUserContract(int userID, int contractID)
        {
            try
            {
                var pivot = await _pivot.GetSinglePivotData(userID,contractID);
                if (pivot == null)
                {
                    return CustomResult("Pivot non trovato", HttpStatusCode.NotFound);
                }

                return CustomResult("Pivot Trovato", pivot);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST: api/Pivot
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostPivotUserContract(PivotUserContract pivotUserContract)
        {
            try
            {
                var pivot = await _pivot.CreatePivotData(pivotUserContract);
                if (pivot == null)
                {
                    return CustomResult("Creazione Fallita", HttpStatusCode.NotFound);
                }

                return CustomResult("Creazione Utente Effettuata", pivot);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Pivot/5
        [HttpDelete("{userID}/{contractID}")]
        public async Task<IActionResult> DeletePivotUserContract(int userID, int contractID)
        {
            try
            {
                var pivots = await _pivot.GetPivotDataAsync();
                if (pivots == null)
                {
                    return CustomResult("Lista Utenti vuota", pivots);
                }
                var pivot = await _pivot.DeletePivotData(userID, contractID);
                if (pivot == null)
                {
                    return CustomResult("Eliminazione Fallita, ID non trovato", HttpStatusCode.NotFound);
                }

                return CustomResult("Eliminazione Utente Effettuata", pivot);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


    }
}
