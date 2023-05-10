using AnastasiaDBCursach.Models;

namespace AnastasiaDBCursach.Services.EventType
{
    public interface IEventService
    {
        Task<List<TableEvent>> GetAll();
        Task<List<TableEvent>> Add(TableEvent position);
        Task<List<TableEvent>?> Delete(int id);
        Task<List<TableEvent>?> Edit(TableEvent position);
    }
}
