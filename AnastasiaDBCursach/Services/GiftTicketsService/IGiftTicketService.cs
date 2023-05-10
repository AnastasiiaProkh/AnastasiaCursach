using AnastasiaDBCursach.Models;

namespace AnastasiaDBCursach.Services.EventType
{
    public interface IGiftTicketService
    {
        Task<List<TableGiftTicket>> GetAll();
        Task<List<TableGiftTicket>> Add(TableGiftTicket position);
        Task<List<TableGiftTicket>?> Delete(int id);
        Task<List<TableGiftTicket>?> Edit(TableGiftTicket position);
    }
}
