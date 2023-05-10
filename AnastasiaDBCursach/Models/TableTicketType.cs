using System;
using System.Collections.Generic;

namespace AnastasiaDBCursach.Models;

public partial class TableTicketType
{
    public int Id { get; set; }

    public string? Ttype { get; set; }

    public virtual ICollection<TableTicket> TableTickets { get; set; } = new List<TableTicket>();
}
