using AnastasiaDBCursach.Context;
using AnastasiaDBCursach.Models;
using Microsoft.EntityFrameworkCore;

namespace AnastasiaDBCursach.Services.TicketType
{
    public class TicketTypeService : ITicketTypeService
    {
        private readonly ПрохорчукКасаКонцертноРозважальнихЗаходівContext _context;
        public TicketTypeService(ПрохорчукКасаКонцертноРозважальнихЗаходівContext context)
        {
            _context = context;
        }
        public async Task<List<TableTicketType>> AddTicketType(TableTicketType staff)
        {
            _context.TableTicketTypes.Add(staff);
            await _context.SaveChangesAsync();
            return _context.TableTicketTypes.ToList();
        }

        public async Task<List<TableTicketType>?> DeleteTicketType(int id)
        {
            var typeToDelete = _context.TableTicketTypes.Find(id);
            if (typeToDelete is null)
                return null;
            _context.TableTicketTypes.Remove(typeToDelete);
            await _context.SaveChangesAsync();
            return _context.TableTicketTypes.ToList();

        }

        public async Task<List<TableTicketType>> GetAllTicketTypes()
        {
            return await _context.TableTicketTypes.ToListAsync();
        }

        public async Task<List<TableTicketType>?> UpdateTicketType(TableTicketType staff)
        {
            var typetoEdit = _context.TableTicketTypes.Find(staff.Id);
            if (typetoEdit is null)
                return null;
            typetoEdit.Ttype = staff.Ttype;
            await _context.SaveChangesAsync();
            return _context.TableTicketTypes.ToList();
        }
    }
}
