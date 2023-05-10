using AnastasiaDBCursach.Context;
using AnastasiaDBCursach.Models;
using Microsoft.EntityFrameworkCore;

namespace AnastasiaDBCursach.Services.EventType
{
    public class SponsorService : ISponsorsService
    {
        private readonly ПрохорчукКасаКонцертноРозважальнихЗаходівContext _context;
        public SponsorService(ПрохорчукКасаКонцертноРозважальнихЗаходівContext context)
        {
            _context = context;
        }
        public async Task<List<TableSponsor>> Add(TableSponsor position)
        {
            _context.TableSponsors.Add(position);
            await _context.SaveChangesAsync();
            return _context.TableSponsors.ToList();
        }

        public async Task<List<TableSponsor>?> Delete(int id)
        {
            var eventTypeToDelete = _context.TableSponsors.Find(id);
            if (eventTypeToDelete is null)
                return null;
            _context.TableSponsors.Remove(eventTypeToDelete);
            await _context.SaveChangesAsync();
            return _context.TableSponsors.ToList();
        }

        public async Task<List<TableSponsor>?> Edit(TableSponsor position)
        {
            var eventTypeToEdit = _context.TableSponsors.Find(position.Id);
            if (eventTypeToEdit is null)
                return null;
            eventTypeToEdit.SponsorName = position.SponsorName;
            eventTypeToEdit.SdateOfIssue = position.SdateOfIssue;
            eventTypeToEdit.SgeneralManagerName = position.SgeneralManagerName;
            eventTypeToEdit.Scontacts = position.Scontacts;
            eventTypeToEdit.SbankAccountNumber = position.SbankAccountNumber;
            await _context.SaveChangesAsync();
            return _context.TableSponsors.ToList();
        }

        public async Task<List<TableSponsor>> GetAll()
        {
            return await _context.TableSponsors.ToListAsync();
        }
    }
}
