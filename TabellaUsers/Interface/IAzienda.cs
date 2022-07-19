using TabellaUsers.DataModel;

namespace TabellaUsers.Interface
{
    public interface IAzienda
    {
        Task<List<ModelAzienda>> GetAllAziendaAsync();
        Task<List<ModelAzienda>> GetAzienda_ID_Async(int id);

        Task<ModelAzienda> CreateAziendaAsync(ModelAzienda user);

        Task<ModelAzienda> UpdateAziendaAsync(int id, ModelAzienda user);

        Task<ModelAzienda> DeleteAziendaAsync(int id);
    }
}
