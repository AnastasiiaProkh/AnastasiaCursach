using AnastasiaDBCursach.Models;
using AnastasiaDBCursach.ResponseModels;

namespace AnastasiaDBCursach.Services.StaffService
{
    public interface IStaffService
    {
        Task<List<Staff>> GetAllStaff();
        Task<TableStaff?> GetStaff(int id);
        Task<List<Staff>> AddStaff(TableStaff staff);
        Task<List<Staff>?> UpdateStaff(TableStaff staff);
        Task<List<Staff>?> DeleteStaff(int id);
    }
}
