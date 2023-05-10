using AnastasiaDBCursach.Models;

namespace AnastasiaDBCursach.Services.EventType
{
    public interface ISponsorsService
    {
        Task<List<TableSponsor>> GetAll();
        Task<List<TableSponsor>> Add(TableSponsor position);
        Task<List<TableSponsor>?> Delete(int id);
        Task<List<TableSponsor>?> Edit(TableSponsor position);
    }
}
