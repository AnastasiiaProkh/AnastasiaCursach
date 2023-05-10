using AnastasiaDBCursach.Models;

namespace AnastasiaDBCursach.Services.EventType
{
    public interface ITicketService
    {
        Task<List<TableTicket>> GetAll();
        Task<List<TableTicket>> Add(TableTicket position);
        Task<List<TableTicket>?> Delete(int id);
        Task<List<TableTicket>?> Edit(TableTicket position);
    }
}
