using AnastasiaDBCursach.Context;
using AnastasiaDBCursach.Models;
using Microsoft.EntityFrameworkCore;

namespace AnastasiaDBCursach.Services.EventType
{
    public class RegularCustomerService : IRegularCustomerService
    {
        private readonly ПрохорчукКасаКонцертноРозважальнихЗаходівContext _context;
        public RegularCustomerService(ПрохорчукКасаКонцертноРозважальнихЗаходівContext context)
        {
            _context = context;
        }
        public async Task<List<TableRegularCustomer>> Add(TableRegularCustomer position)
        {
            _context.TableRegularCustomers.Add(position);
            await _context.SaveChangesAsync();
            return _context.TableRegularCustomers.ToList();
        }

        public async Task<List<TableRegularCustomer>?> Delete(int id)
        {
            var eventTypeToDelete = _context.TableRegularCustomers.Find(id);
            if (eventTypeToDelete is null)
                return null;
            _context.TableRegularCustomers.Remove(eventTypeToDelete);
            await _context.SaveChangesAsync();
            return _context.TableRegularCustomers.ToList();
        }

        public async Task<List<TableRegularCustomer>?> Edit(TableRegularCustomer position)
        {
            var eventTypeToEdit = _context.TableRegularCustomers.Find(position.Id);
            if (eventTypeToEdit is null)
                return null;
            eventTypeToEdit.Rcname = position.Rcname;
            eventTypeToEdit.RcbirthDate = position.RcbirthDate;
            eventTypeToEdit.RcdateOfIssue = position.RcdateOfIssue;
            eventTypeToEdit.Rccontacts = position.Rccontacts;
            await _context.SaveChangesAsync();
            return _context.TableRegularCustomers.ToList();
        }

        public async Task<List<TableRegularCustomer>> GetAll()
        {
            return await _context.TableRegularCustomers.ToListAsync();
        }
    }
}
