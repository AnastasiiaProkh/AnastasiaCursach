using AnastasiaDBCursach.Context;
using AnastasiaDBCursach.Models;
using Microsoft.EntityFrameworkCore;

namespace AnastasiaDBCursach.Services.EventType
{
    public class RescheduledEventsService : IRescheduledEventsServices
    {
        private readonly ПрохорчукКасаКонцертноРозважальнихЗаходівContext _context;
        public RescheduledEventsService(ПрохорчукКасаКонцертноРозважальнихЗаходівContext context)
        {
            _context = context;
        }
        public async Task<List<TableRescheduledEvent>> Add(TableRescheduledEvent position)
        {
            _context.TableRescheduledEvents.Add(position);
            await _context.SaveChangesAsync();
            return _context.TableRescheduledEvents.ToList();
        }

        public async Task<List<TableRescheduledEvent>?> Delete(int id)
        {
            var eventTypeToDelete = _context.TableRescheduledEvents.Find(id);
            if (eventTypeToDelete is null)
                return null;
            _context.TableRescheduledEvents.Remove(eventTypeToDelete);
            await _context.SaveChangesAsync();
            return _context.TableRescheduledEvents.ToList();
        }

        public async Task<List<TableRescheduledEvent>?> Edit(TableRescheduledEvent position)
        {
            var eventTypeToEdit = _context.TableRescheduledEvents.Find(position.Id);
            if (eventTypeToEdit is null)
                return null;
            eventTypeToEdit.EventId = position.EventId;
            eventTypeToEdit.Status = position.Status;
            eventTypeToEdit.NewTime = position.NewTime;
            eventTypeToEdit.NewDate = position.NewDate;
            await _context.SaveChangesAsync();
            return _context.TableRescheduledEvents.ToList();
        }

        public async Task<List<TableRescheduledEvent>> GetAll()
        {
            return await _context.TableRescheduledEvents.ToListAsync();
        }
    }
}
