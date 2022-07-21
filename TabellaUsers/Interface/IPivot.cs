using TabellaUsers.DataModel;

namespace TabellaUsers.Interface
{
    public interface IPivot
    {
        Task<List<PivotUserContract>> GetPivotDataAsync();
        Task<PivotUserContract> GetSinglePivotData(int userID, int contractID);
        Task<PivotUserContract> CreatePivotData(PivotUserContract pivotUserContract);
        Task<PivotUserContract> DeletePivotData(int userID, int contractID);


    }
}
