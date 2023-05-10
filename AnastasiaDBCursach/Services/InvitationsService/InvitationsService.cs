using AnastasiaDBCursach.Context;
using AnastasiaDBCursach.Models;
using Microsoft.EntityFrameworkCore;

namespace AnastasiaDBCursach.Services.EventType
{
    public class InvitationService : IInvitationService
    {
        private readonly ПрохорчукКасаКонцертноРозважальнихЗаходівContext _context;
        public InvitationService(ПрохорчукКасаКонцертноРозважальнихЗаходівContext context)
        {
            _context = context;
        }
        public async Task<List<TableInvitation>> Add(TableInvitation position)
        {
            _context.TableInvitations.Add(position);
            await _context.SaveChangesAsync();
            return _context.TableInvitations.ToList();
        }

        public async Task<List<TableInvitation>?> Delete(int id)
        {
            var eventTypeToDelete = _context.TableInvitations.Find(id);
            if (eventTypeToDelete is null)
                return null;
            _context.TableInvitations.Remove(eventTypeToDelete);
            await _context.SaveChangesAsync();
            return _context.TableInvitations.ToList();
        }

        public async Task<List<TableInvitation>?> Edite(TableInvitation position)
        {
            var eventTypeToEdit = _context.TableInvitations.Find(position.Id);
            if (eventTypeToEdit is null)
                return null;
            eventTypeToEdit.Iname = position.Iname;
            eventTypeToEdit.EventId = position.EventId;
            eventTypeToEdit.Istatus = position.Istatus;
            eventTypeToEdit.Ifee = position.Ifee;
            eventTypeToEdit.Irider = position.Irider;
            eventTypeToEdit.Icontacts = position.Icontacts;
            eventTypeToEdit.IbankAccountNumber = position.IbankAccountNumber;
            await _context.SaveChangesAsync();
            return _context.TableInvitations.ToList();
        }

        public async Task<List<TableInvitation>> GetAll()
        {
            return await _context.TableInvitations.ToListAsync();
        }
    }
}
