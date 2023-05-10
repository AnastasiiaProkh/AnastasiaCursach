using AnastasiaDBCursach.Models;

namespace AnastasiaDBCursach.Services.EventType
{
    public interface IEventTypeService
    {
        Task<List<TableEventType>> GetAllEventTypes();
        Task<List<TableEventType>> AddEventType(TableEventType position);
        Task<List<TableEventType>?> DeleteEventType(int id);
        Task<List<TableEventType>?> EditEventType(TableEventType position);
    }
}
