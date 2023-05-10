using AnastasiaDBCursach.Models;

namespace AnastasiaDBCursach.ResponseModels
{
    public class Staff
    {
        public int Id { get; set; }

        public string? StName { get; set; }

        public DateTime? StBirthDate { get; set; }

        public decimal? StComm { get; set; }

        public string? StContacts { get; set; }

        public string? StBankAccountNumber { get; set; }

        public int? PositionId { get; set; }

        public Staff(TableStaff staff)
        {
            Id= staff.Id;
            StName = staff.StName;
            StContacts = staff.StContacts;
            StComm = staff.StComm;
            StBirthDate = staff.StBirthDate;
            StBankAccountNumber = staff.StBankAccountNumber;
            PositionId = staff.PositionId;
        }
    }
}
