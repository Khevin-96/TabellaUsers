using TabellaUsers.DataModel;

namespace TabellaUsers.Interface
{
    public interface IContract
    {
        Task<List<ModelContract>> GetAllContractAsync();
        Task<List<ModelContract>> GetContract_ID_Async(int id);

        Task<ModelContract> CreateContractAsync(ModelContract user);

        Task<ModelContract> UpdateContractAsync(int id, ModelContract user);

        Task<ModelContract> DeleteContractAsync(int id);
    }
}
