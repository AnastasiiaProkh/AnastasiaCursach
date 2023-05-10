using AnastasiaDBCursach.Models;

namespace AnastasiaDBCursach.Services.EventType
{
    public interface IInvitationService
    {
        Task<List<TableInvitation>> GetAll();
        Task<List<TableInvitation>> Add(TableInvitation position);
        Task<List<TableInvitation>?> Delete(int id);
        Task<List<TableInvitation>?> Edite(TableInvitation position);
    }
}
