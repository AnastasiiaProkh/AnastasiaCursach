using AnastasiaDBCursach.Context;
using AnastasiaDBCursach.Models;
using Microsoft.EntityFrameworkCore;

namespace AnastasiaDBCursach.Services.EventType
{
    public class EventTypeService : IEventTypeService
    {
        private readonly ПрохорчукКасаКонцертноРозважальнихЗаходівContext _context;
        public EventTypeService(ПрохорчукКасаКонцертноРозважальнихЗаходівContext context)
        {
            _context = context;
        }
        public async Task<List<TableEventType>> AddEventType(TableEventType position)
        {
            _context.TableEventTypes.Add(position);
            await _context.SaveChangesAsync();
            return _context.TableEventTypes.ToList();
        }

        public async Task<List<TableEventType>?> DeleteEventType(int id)
        {
            var eventTypeToDelete = _context.TableEventTypes.Find(id);
            if (eventTypeToDelete is null)
                return null;
            _context.TableEventTypes.Remove(eventTypeToDelete);
            await _context.SaveChangesAsync();
            return _context.TableEventTypes.ToList();
        }

        public async Task<List<TableEventType>?> EditEventType(TableEventType position)
        {
            var eventTypeToEdit = _context.TableEventTypes.Find(position.Id);
            if (eventTypeToEdit is null)
                return null;
            eventTypeToEdit.Etype = position.Etype;
            await _context.SaveChangesAsync();
            return _context.TableEventTypes.ToList();
        }

        public async Task<List<TableEventType>> GetAllEventTypes()
        {
            return await _context.TableEventTypes.ToListAsync();
        }
    }
}
