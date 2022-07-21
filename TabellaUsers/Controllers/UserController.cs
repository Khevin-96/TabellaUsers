
using Microsoft.AspNetCore.Http;
using CoreApiResponse;
using TabellaUsers.DataModel;
using TabellaUsers.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TabellaUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }

        // GET: api/ModelUsers
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _user.GetAllUsersAsync();
                if (users==null)
                {
                    return CustomResult("Utenti non trovati", HttpStatusCode.NotFound);
                }
                return CustomResult("Utenti Caricati", users);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        
        }

        // GET: api/ModelUsers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetModelUsers(int id)
        {
            try
            {
                var users = await _user.GetUsers_ID_Async(id);
                if (users==null)
                {
                    return CustomResult("Utente non trovato", HttpStatusCode.NotFound);
                }
                
                return CustomResult("Utente Trovato", users);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // PUT: api/ModelUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelUsers(int id, ModelUsers modelUsers)
        {

            try
            {
                var users = await _user.UpdateUsersAsync(id,modelUsers);
                if (users == null)
                {
                    return CustomResult("Modifica fallita, l'ID è errato", HttpStatusCode.NotFound);
                }

                return CustomResult("Utente Modificato", users);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        // POST: api/ModelUsers
        [HttpPost]
        public async Task<IActionResult> PostModelUsers(ModelUsers modelUsers)
        {
            try
            {
                var users = await _user.CreateUsersAsync(modelUsers);
                if (users == null)
                {
                    return CustomResult("Creazione Fallita", HttpStatusCode.NotFound);
                }

                return CustomResult("Creazione Utente Effettuata", users);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/ModelUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelUsers(int id)
        {
            try
            {
                var user= await _user.GetAllUsersAsync();
                if (user==null)
                {
                    return CustomResult("Lista Utenti vuota", user);
                }
                var users = await _user.DeleteUsersAsync(id);
                if (users == null)
                {
                    return CustomResult("Eliminazione Fallita, ID non trovato", HttpStatusCode.NotFound);
                }

                return CustomResult("Eliminazione Utente Effettuata", users);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
