using AnastasiaDBCursach.Models;
using AnastasiaDBCursach.ResponseModels;

namespace AnastasiaDBCursach.Services.TicketType
{
    public interface ITicketTypeService
    {
        Task<List<TableTicketType>> GetAllTicketTypes();
        Task<List<TableTicketType>> AddTicketType(TableTicketType staff);
        Task<List<TableTicketType>?> UpdateTicketType(TableTicketType staff);
        Task<List<TableTicketType>?> DeleteTicketType(int id);
    }
}
