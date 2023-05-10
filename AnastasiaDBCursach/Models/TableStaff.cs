using System;
using System.Collections.Generic;

namespace AnastasiaDBCursach.Models;

public partial class TableStaff
{
    public int Id { get; set; }

    public string? StName { get; set; }

    public DateTime? StBirthDate { get; set; }

    public decimal? StComm { get; set; }

    public string? StContacts { get; set; }

    public string? StBankAccountNumber { get; set; }

    public int? PositionId { get; set; }

    public virtual TablePosition? Position { get; set; }

    public virtual ICollection<TableTicket> TableTickets { get; set; } = new List<TableTicket>();
}
