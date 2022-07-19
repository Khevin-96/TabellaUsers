using TabellaUsers.DataModel;

namespace TabellaUsers.Interface
{
    public interface IUser
    {
        Task<List<ModelUsers>> GetAllUsersAsync();
        Task<List<ModelUsers>> GetUsers_ID_Async(int id);

        Task<ModelUsers> CreateUsersAsync(ModelUsers user);

        Task<ModelUsers> UpdateUsersAsync(int id,ModelUsers user);

        Task<ModelUsers> DeleteUsersAsync(int id);
    }
}
