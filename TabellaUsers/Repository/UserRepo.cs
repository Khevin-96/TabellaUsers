using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TabellaUsers.DataModel;
using TabellaUsers.Interface;

namespace TabellaUsers.Repository
{
    public class UserRepo : IUser
    {
        private readonly DataContext _context;

        public UserRepo(DataContext context)
        {
            _context = context;
        }


        public async Task<ModelUsers> CreateUsersAsync(ModelUsers user)
        {
            if (user.Name==null && user.SurName==null)
            {
                return null;
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<ModelUsers> DeleteUsersAsync(int id)
        {
            if (_context.Users == null)
            {
                return null;
            }
            var modelUsers = await _context.Users.Include(b => b.Contracts)
                .Where(c => c.UserId == id).FirstOrDefaultAsync();

            if (modelUsers == null)
            {
                return null;
            }

            _context.Users.Remove(modelUsers);
            
            await _context.SaveChangesAsync();

            return modelUsers;
        }

        public async Task<List<ModelUsers>> GetAllUsersAsync()
        {
            if (_context.Users == null)
            {
                return null;
            } 

            return await _context.Users.Include(a => a.Contracts).ThenInclude(c => c.contract).Include(b => b.Azienda).ToListAsync();
        }

        public async Task<ModelUsers>? GetUsers_ID_Async(int id)
        {
            if (_context.Users == null)
            {
                return null;
            }
            var modelUsers = await _context.Users.Include(a => a.Azienda).Include(c => c.Contracts).ThenInclude(c => c.contract).Where(c=>c.UserId == id).FirstOrDefaultAsync();

            return modelUsers;
        }

        public async Task<ModelUsers>? UpdateUsersAsync(int id, ModelUsers modelUsers)
        {
            if (id != modelUsers.UserId)
            {
                return null;
            }

            _context.Entry(modelUsers).State = EntityState.Modified;

                try
                {
                    _context.Users.Update(modelUsers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelUsersExists(id))
                    {
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }

            return modelUsers;
        }

        private bool ModelUsersExists(int id)
        {
            return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
