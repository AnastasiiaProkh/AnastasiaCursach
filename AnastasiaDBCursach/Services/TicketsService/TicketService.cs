using AnastasiaDBCursach.Context;
using AnastasiaDBCursach.Models;
using Microsoft.EntityFrameworkCore;

namespace AnastasiaDBCursach.Services.EventType
{
    public class TicketService : ITicketService
    {
        private readonly ПрохорчукКасаКонцертноРозважальнихЗаходівContext _context;
        public TicketService(ПрохорчукКасаКонцертноРозважальнихЗаходівContext context)
        {
            _context = context;
        }
        public async Task<List<TableTicket>> Add(TableTicket position)
        {
            _context.TableTickets.Add(position);
            await _context.SaveChangesAsync();
            return _context.TableTickets.ToList();
        }

        public async Task<List<TableTicket>?> Delete(int id)
        {
            var eventTypeToDelete = _context.TableTickets.Find(id);
            if (eventTypeToDelete is null)
                return null;
            _context.TableTickets.Remove(eventTypeToDelete);
            await _context.SaveChangesAsync();
            return _context.TableTickets.ToList();
        }

        public async Task<List<TableTicket>?> Edit(TableTicket position)
        {
            var eventTypeToEdit = _context.TableTickets.Find(position.Id);
            if (eventTypeToEdit is null)
                return null;
            eventTypeToEdit.EventId = position.EventId;
            eventTypeToEdit.Etype = position.Etype;
            eventTypeToEdit.Ttype = position.Ttype;
            eventTypeToEdit.Trow = position.Trow;
            eventTypeToEdit.Tseat = position.Tseat;
            eventTypeToEdit.Tsector = position.Tsector;
            eventTypeToEdit.Tprice = position.Tprice;
            eventTypeToEdit.RcustomerId = position.RcustomerId;
            eventTypeToEdit.TdateOfPurchase = position.TdateOfPurchase;
            eventTypeToEdit.StaffId = position.StaffId;
            await _context.SaveChangesAsync();
            return _context.TableTickets.ToList();
        }

        public async Task<List<TableTicket>> GetAll()
        {
            return await _context.TableTickets.ToListAsync();
        }
    }
}
