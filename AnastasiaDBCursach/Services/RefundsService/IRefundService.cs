using AnastasiaDBCursach.Models;

namespace AnastasiaDBCursach.Services.EventType
{
    public interface IRefundService
    {
        Task<List<TableRefund>> GetAll();
        Task<List<TableRefund>> Add(TableRefund position);
        Task<List<TableRefund>?> Delete(int id);
        Task<List<TableRefund>?> Edit(TableRefund position);
    }
}
