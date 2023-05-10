using AnastasiaDBCursach.Context;
using AnastasiaDBCursach.Models;
using Microsoft.EntityFrameworkCore;

namespace AnastasiaDBCursach.Services.EventType
{
    public class AddvertisinAgenciesService : IAddvertisinAgenciesService
    {
        private readonly ПрохорчукКасаКонцертноРозважальнихЗаходівContext _context;
        public AddvertisinAgenciesService(ПрохорчукКасаКонцертноРозважальнихЗаходівContext context)
        {
            _context = context;
        }
        public async Task<List<TableAdvertisingAgency>> Add(TableAdvertisingAgency record)
        {
            _context.TableAdvertisingAgencies.Add(record);
            await _context.SaveChangesAsync();
            return _context.TableAdvertisingAgencies.ToList();
        }

        public async Task<List<TableAdvertisingAgency>?> Delete(int id)
        {
            var eventTypeToDelete = _context.TableAdvertisingAgencies.Find(id);
            if (eventTypeToDelete is null)
                return null;
            _context.TableAdvertisingAgencies.Remove(eventTypeToDelete);
            await _context.SaveChangesAsync();
            return _context.TableAdvertisingAgencies.ToList();
        }

        public async Task<List<TableAdvertisingAgency>?> Edit(TableAdvertisingAgency record)
        {
            var recordToEdit = _context.TableAdvertisingAgencies.Find(record.AgencyId);
            if (recordToEdit is null)
                return null;
            recordToEdit.EventId = record.EventId;
            recordToEdit.AdateOfIssue = record.AdateOfIssue;
            recordToEdit.AbankAccountNumber = record.AbankAccountNumber;
            recordToEdit.Aaddress = record.Aaddress;
            recordToEdit.Aname = record.Aname;
            await _context.SaveChangesAsync();
            return _context.TableAdvertisingAgencies.ToList();
        }

        public async Task<List<TableAdvertisingAgency>> GetAll()
        {
            return await _context.TableAdvertisingAgencies.ToListAsync();
        }
    }
}
