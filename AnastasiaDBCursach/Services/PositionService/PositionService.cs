using AnastasiaDBCursach.Context;
using AnastasiaDBCursach.Models;
using Microsoft.EntityFrameworkCore;

namespace AnastasiaDBCursach.Services.PositionService
{
    public class PositionService:IPositionService
    {
        private readonly ПрохорчукКасаКонцертноРозважальнихЗаходівContext _context;

        public PositionService(ПрохорчукКасаКонцертноРозважальнихЗаходівContext context)
        {
            _context = context;
        }

        public async Task<List<TablePosition>> GetAllPositions()
        {
            return await _context.TablePositions.ToListAsync();
        }

        public async Task<List<TablePosition>> AddPosition(TablePosition position)
        {
            _context.TablePositions.Add(position);
            await _context.SaveChangesAsync();
            return _context.TablePositions.ToList();
        }

        public async Task<List<TablePosition>?> DeletePosition(int id)
        {
            var positionToDelete = _context.TablePositions.Find(id);
            if (positionToDelete is null)
                return null;
            _context.Remove(positionToDelete);
            await _context.SaveChangesAsync();
            return _context.TablePositions.ToList();
            
        }

        public async Task<List<TablePosition>?> EditPosition(TablePosition position)
        {
            var dbPosition = _context.TablePositions.Find(position.Id);
            if (dbPosition is null)
            {
                return null;
            }
            dbPosition.Name = position.Name;
            await _context.SaveChangesAsync();
            return _context.TablePositions.ToList();
        }
    }
}
