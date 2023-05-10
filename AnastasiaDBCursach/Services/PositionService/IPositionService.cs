using AnastasiaDBCursach.Models;

namespace AnastasiaDBCursach.Services.PositionService
{
    public interface IPositionService
    {
        Task<List<TablePosition>> GetAllPositions();
        Task<List<TablePosition>> AddPosition(TablePosition position);
        Task<List<TablePosition>?> DeletePosition(int id);
        Task<List<TablePosition>?> EditPosition(TablePosition position);
    }
}
