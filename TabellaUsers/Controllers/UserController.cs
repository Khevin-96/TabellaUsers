
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TabellaUsers.DataModel;
using TabellaUsers.Interface;

namespace TabellaUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }

        // GET: api/ModelUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelUsers>>> GetUsers()
        {
            var users = await _user.GetAllUsersAsync();

            return Ok(users);
        }

        // GET: api/ModelUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModelUsers>> GetModelUsers(int id)
        {
            var users = await _user.GetUsers_ID_Async(id);

            return Ok(users);
        }

        // PUT: api/ModelUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelUsers(int id, ModelUsers modelUsers)
        {
            var user = await _user.UpdateUsersAsync(id, modelUsers);

            return Ok(user);
        }


        // POST: api/ModelUsers
        [HttpPost]
        public async Task<ActionResult<ModelUsers>> PostModelUsers(ModelUsers modelUsers)
        {
            var user= await _user.CreateUsersAsync(modelUsers);

            return Ok(user);
        }

        // DELETE: api/ModelUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelUsers(int id)
        {
            var user= await _user.DeleteUsersAsync(id);

            return Ok(user);
        }

    }
}
