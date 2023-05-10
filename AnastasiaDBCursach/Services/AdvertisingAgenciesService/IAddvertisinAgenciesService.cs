using AnastasiaDBCursach.Models;

namespace AnastasiaDBCursach.Services.EventType
{
    public interface IAddvertisinAgenciesService
    {
        Task<List<TableAdvertisingAgency>> GetAll();
        Task<List<TableAdvertisingAgency>> Add(TableAdvertisingAgency record);
        Task<List<TableAdvertisingAgency>?> Delete(int id);
        Task<List<TableAdvertisingAgency>?> Edit(TableAdvertisingAgency record);
    }
}
