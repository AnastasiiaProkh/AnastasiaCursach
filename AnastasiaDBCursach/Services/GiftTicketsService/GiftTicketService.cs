using AnastasiaDBCursach.Context;
using AnastasiaDBCursach.Models;
using Microsoft.EntityFrameworkCore;

namespace AnastasiaDBCursach.Services.EventType
{
    public class GiftTicketService : IGiftTicketService
    {
        private readonly ПрохорчукКасаКонцертноРозважальнихЗаходівContext _context;
        public GiftTicketService(ПрохорчукКасаКонцертноРозважальнихЗаходівContext context)
        {
            _context = context;
        }
        public async Task<List<TableGiftTicket>> Add(TableGiftTicket position)
        {
            _context.TableGiftTickets.Add(position);
            await _context.SaveChangesAsync();
            return _context.TableGiftTickets.ToList();
        }

        public async Task<List<TableGiftTicket>?> Delete(int id)
        {
            var eventTypeToDelete = _context.TableGiftTickets.Find(id);
            if (eventTypeToDelete is null)
                return null;
            _context.TableGiftTickets.Remove(eventTypeToDelete);
            await _context.SaveChangesAsync();
            return _context.TableGiftTickets.ToList();
        }

        public async Task<List<TableGiftTicket>?> Edit(TableGiftTicket position)
        {
            var eventTypeToEdit = _context.TableGiftTickets.Find(position.GiftTicketId);
            if (eventTypeToEdit is null)
                return null;
            eventTypeToEdit.TicketId = position.TicketId;
            eventTypeToEdit.Tprice = position.Tprice;
            eventTypeToEdit.TdateOfPurchase = position.TdateOfPurchase;
            await _context.SaveChangesAsync();
            return _context.TableGiftTickets.ToList();
        }

        public async Task<List<TableGiftTicket>> GetAll()
        {
            return await _context.TableGiftTickets.ToListAsync();
        }
    }
}
