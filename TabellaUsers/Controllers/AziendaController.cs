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
    public class AziendaController : ControllerBase
    {
        private readonly IAzienda _azienda;

        public AziendaController(IAzienda azienda)
        {
            _azienda = azienda;
        }

        // GET: api/ModelUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelAzienda>>> GetAzienda()
        {
            var azienda = await _azienda.GetAllAziendaAsync();

            return Ok(azienda);
        }

        // GET: api/ModelUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModelAzienda>> GetModelAzienda(int id)
        {
            var azienda = await _azienda.GetAzienda_ID_Async(id);

            return Ok(azienda);
        }

        // PUT: api/ModelUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelAzienda(int id, ModelAzienda modelAzienda)
        {
            var Azienda = await _azienda.UpdateAziendaAsync(id, modelAzienda);

            return Ok(Azienda);
        }


        // POST: api/ModelUsers
        [HttpPost]
        public async Task<ActionResult<ModelAzienda>> PostModelAzienda(ModelAzienda modelAzienda)
        {
            var Azienda = await _azienda.CreateAziendaAsync(modelAzienda);

            return Ok(Azienda);
        }

        // DELETE: api/ModelUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelAzienda(int id)
        {
            var Azienda = await _azienda.DeleteAziendaAsync(id);

            return Ok(Azienda);
        }
    }
}
