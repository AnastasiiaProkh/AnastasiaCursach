using AnastasiaDBCursach.Models;

namespace AnastasiaDBCursach.Services.EventType
{
    public interface IRegularCustomerService
    {
        Task<List<TableRegularCustomer>> GetAll();
        Task<List<TableRegularCustomer>> Add(TableRegularCustomer position);
        Task<List<TableRegularCustomer>?> Delete(int id);
        Task<List<TableRegularCustomer>?> Edit(TableRegularCustomer position);
    }
}
