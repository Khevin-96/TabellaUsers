using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TabellaUsers.DataModel;
using TabellaUsers.Interface;
using CoreApiResponse;
using System.Net;

namespace TabellaUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AziendaController : BaseController
    {
        private readonly IAzienda _azienda;

        public AziendaController(IAzienda azienda)
        {
            _azienda = azienda;
        }

        // GET: api/ModelUsers
        [HttpGet]
        public async Task<IActionResult> GetAzienda()
        {
            try
            {
                var azienda = await _azienda.GetAllAziendaAsync();
                if (azienda == null)
                {
                    return CustomResult("Aziende non trovate", HttpStatusCode.NotFound);
                }
                return CustomResult("Aziende Caricate", azienda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/ModelUsers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetModelAzienda(int id)
        {
            try
            {
                var azienda = await _azienda.GetAzienda_ID_Async(id);
                if (azienda == null)
                {
                    return CustomResult("Azienda non trovata", HttpStatusCode.NotFound);
                }

                return CustomResult("Azienda Trovata", azienda);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT: api/ModelUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelAzienda(int id, ModelAzienda modelAzienda)
        {

            try
            {
                var azienda = await _azienda.UpdateAziendaAsync(id, modelAzienda);
                if (azienda == null)
                {
                    return CustomResult("Modifica fallita, l'ID è errato", HttpStatusCode.NotFound);
                }

                return CustomResult("Azienda Modificata", azienda);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        // POST: api/ModelUsers
        [HttpPost]
        public async Task<IActionResult> PostModelAzienda(ModelAzienda modelAzienda)
        {
            try
            {
                var azienda = await _azienda.CreateAziendaAsync(modelAzienda);
                if (azienda == null)
                {
                    return CustomResult("Creazione Azienda Fallita", HttpStatusCode.NotFound);
                }

                return CustomResult("Creazione Azienda Effettuata", azienda);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/ModelUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelAzienda(int id)
        {
            try
            {
                var aziende = await _azienda.GetAllAziendaAsync();
                if (aziende == null)
                {
                    return CustomResult("Lista Aziende vuota", aziende);
                }
                var azienda = await _azienda.DeleteAziendaAsync(id);
                if (azienda == null)
                {
                    return CustomResult("Eliminazione Fallita, ID non trovato o Azienda già eliminata", HttpStatusCode.NotFound);
                }

                return CustomResult("Eliminazione Azienda Effettuata", azienda);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
