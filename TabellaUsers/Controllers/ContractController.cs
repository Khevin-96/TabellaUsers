using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TabellaUsers.DataModel;
using TabellaUsers.Interface;

namespace TabellaUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContract _contract;
        public ContractController(IContract contract)
        {
            _contract = contract;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelContract>>> GetContract()
        {
            var contract = await _contract.GetAllContractAsync();

            return Ok(contract);
        }

        // GET: api/ModelUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModelContract>> GetModelContract(int id)
        {
            var contract = await _contract.GetContract_ID_Async(id);

            return Ok(contract);
        }

        // PUT: api/ModelUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelContract(int id, ModelContract modelContract)
        {
            var contract = await _contract.UpdateContractAsync(id, modelContract);

            return Ok(contract);
        }


        // POST: api/ModelUsers
        [HttpPost]
        public async Task<ActionResult<ModelContract>> PostModelContract(ModelContract modelContract)
        {
            var contract = await _contract.CreateContractAsync(modelContract);

            return Ok(contract);
        }

        // DELETE: api/ModelUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelContract(int id)
        {
            var contract = await _contract.DeleteContractAsync(id);

            return Ok(contract);
        }
    }
}
