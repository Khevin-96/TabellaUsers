using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TabellaUsers.DataModel;
using TabellaUsers.Interface;
using CoreApiResponse;
using System.Net;

namespace TabellaUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : BaseController
    {
        private readonly IContract _contract;
        public ContractController(IContract contract)
        {
            _contract = contract;
        }

        [HttpGet]
        public async Task<IActionResult> GetContract()
        {
            try
            {
                var contratto = await _contract.GetAllContractAsync();
                if (contratto == null)
                {
                    return CustomResult("Contratti non trovati", HttpStatusCode.NotFound);
                }
                return CustomResult("Contratti Caricati", contratto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/ModelUsers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetModelContract(int id)
        {
            try
            {
                var contratto = await _contract.GetContract_ID_Async(id);
                if (contratto == null)
                {
                    return CustomResult("Contratto non trovato", HttpStatusCode.NotFound);
                }

                return CustomResult("Contratto Trovato", contratto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT: api/ModelUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelContract(int id, ModelContract modelContract)
        {
            try
            {
                var contratto = await _contract.UpdateContractAsync(id, modelContract);
                if (contratto == null)
                {
                    return CustomResult("Modifica fallita, l'ID è errato", HttpStatusCode.NotFound);
                }

                return CustomResult("Contratto Modificato", contratto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        // POST: api/ModelUsers
        [HttpPost]
        public async Task<IActionResult> PostModelContract(ModelContract modelContract)
        {
            try
            {
                var contratto = await _contract.CreateContractAsync(modelContract);
                if (contratto == null)
                {
                    return CustomResult("Creazione Fallita", HttpStatusCode.NotFound);
                }

                return CustomResult("Creazione Contratto Effettuata", contratto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/ModelUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelContract(int id)
        {
            try
            {
                var contratti = await _contract.GetAllContractAsync();
                if (contratti == null)
                {
                    return CustomResult("Lista Contratti vuota", contratti);
                }
                var contratto = await _contract.DeleteContractAsync(id);
                if (contratto == null)
                {
                    return CustomResult("Eliminazione Fallita, ID non trovato", HttpStatusCode.NotFound);
                }

                return CustomResult("Eliminazione Contratto Effettuata", contratto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
