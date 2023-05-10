using AnastasiaDBCursach.Context;
using AnastasiaDBCursach.Models;
using Microsoft.EntityFrameworkCore;

namespace AnastasiaDBCursach.Services.EventType
{
    public class RefundService : IRefundService
    {
        private readonly ПрохорчукКасаКонцертноРозважальнихЗаходівContext _context;
        public RefundService(ПрохорчукКасаКонцертноРозважальнихЗаходівContext context)
        {
            _context = context;
        }
        public async Task<List<TableRefund>> Add(TableRefund position)
        {
            _context.TableRefunds.Add(position);
            await _context.SaveChangesAsync();
            return _context.TableRefunds.ToList();
        }

        public async Task<List<TableRefund>?> Delete(int id)
        {
            var eventTypeToDelete = _context.TableRefunds.Find(id);
            if (eventTypeToDelete is null)
                return null;
            _context.TableRefunds.Remove(eventTypeToDelete);
            await _context.SaveChangesAsync();
            return _context.TableRefunds.ToList();
        }

        public async Task<List<TableRefund>?> Edit(TableRefund position)
        {
            var eventTypeToEdit = _context.TableRefunds.Find(position.Id);
            if (eventTypeToEdit is null)
                return null;
            eventTypeToEdit.TicketId = position.TicketId;
            eventTypeToEdit.Rstatus = position.Rstatus;
            await _context.SaveChangesAsync();
            return _context.TableRefunds.ToList();
        }

        public async Task<List<TableRefund>> GetAll()
        {
            return await _context.TableRefunds.ToListAsync();
        }
    }
}
