using AnastasiaDBCursach.Context;
using AnastasiaDBCursach.Models;
using Microsoft.EntityFrameworkCore;

namespace AnastasiaDBCursach.Services.EventType
{
    public class EventService : IEventService
    {
        private readonly ПрохорчукКасаКонцертноРозважальнихЗаходівContext _context;
        public EventService(ПрохорчукКасаКонцертноРозважальнихЗаходівContext context)
        {
            _context = context;
        }
        public async Task<List<TableEvent>> Add(TableEvent position)
        {
            _context.TableEvents.Add(position);
            await _context.SaveChangesAsync();
            return _context.TableEvents.ToList();
        }

        public async Task<List<TableEvent>?> Delete(int id)
        {
            var eventTypeToDelete = _context.TableEvents.Find(id);
            if (eventTypeToDelete is null)
                return null;
            _context.TableEvents.Remove(eventTypeToDelete);
            await _context.SaveChangesAsync();
            return _context.TableEvents.ToList();
        }

        public async Task<List<TableEvent>?> Edit(TableEvent position)
        {
            var eventTypeToEdit = _context.TableEvents.Find(position.Id);
            if (eventTypeToEdit is null)
                return null;
            eventTypeToEdit.Etype = position.Etype;
            eventTypeToEdit.Edate = position.Edate;
            eventTypeToEdit.Etime = position.Etime;
            eventTypeToEdit.Ename = position.Ename;
            eventTypeToEdit.SponsorId = position.SponsorId;

            await _context.SaveChangesAsync();
            return _context.TableEvents.ToList();
        }

        public async Task<List<TableEvent>> GetAll()
        {
            return await _context.TableEvents.ToListAsync();
        }
    }
}
