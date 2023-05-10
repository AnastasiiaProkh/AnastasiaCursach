using AnastasiaDBCursach.Models;

namespace AnastasiaDBCursach.Services.EventType
{
    public interface IRescheduledEventsServices
    {
        Task<List<TableRescheduledEvent>> GetAll();
        Task<List<TableRescheduledEvent>> Add(TableRescheduledEvent position);
        Task<List<TableRescheduledEvent>?> Delete(int id);
        Task<List<TableRescheduledEvent>?> Edit(TableRescheduledEvent position);
    }
}
