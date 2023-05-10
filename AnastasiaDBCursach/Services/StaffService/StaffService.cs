using AnastasiaDBCursach.Context;
using AnastasiaDBCursach.Models;
using AnastasiaDBCursach.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace AnastasiaDBCursach.Services.StaffService
{
    public class StaffService : IStaffService
    {
        private readonly ПрохорчукКасаКонцертноРозважальнихЗаходівContext _context;

        public StaffService(ПрохорчукКасаКонцертноРозважальнихЗаходівContext context)
        {
            _context = context;
        }
        public async Task<List<Staff>> AddStaff(TableStaff staff)
        {
            _context.TableStaffs.Add(staff);
            await _context.SaveChangesAsync();
            return _context.TableStaffs.Select((staff) => new Staff(staff)).ToList();
        }

        public async Task<List<Staff>?> DeleteStaff(int id)
        {
            var staff = _context.TableStaffs.Find(id);
            if(staff is null)
                return null;
            _context.TableStaffs.Remove(staff);
            await _context.SaveChangesAsync();
            return _context.TableStaffs.Select((staff) => new Staff(staff)).ToList();
        }

        public async Task<List<Staff>> GetAllStaff()
        {
            var staff = await _context.TableStaffs.Select((staff)=>new Staff(staff)).ToListAsync();
            return staff;
        }

        public async Task<TableStaff?> GetStaff(int id)
        {
            var staff = await _context.TableStaffs.FindAsync(id);
            if (staff is null)
                return null;
            return staff;
        }

        public async Task<List<Staff>?> UpdateStaff(TableStaff staff)
        {
            var dbStaff = _context.TableStaffs.Find(staff.Id);
            if (dbStaff is null) 
                return null;
            dbStaff.PositionId = staff.PositionId;
            dbStaff.StBirthDate = staff.StBirthDate;
            dbStaff.StBankAccountNumber = staff.StBankAccountNumber;
            dbStaff.StName = staff.StName;
            dbStaff.StComm = staff.StComm;
            dbStaff.StContacts = staff.StContacts;

            await _context.SaveChangesAsync();
            return _context.TableStaffs.Select((staff) => new Staff(staff)).ToList();
        }
    }
}
