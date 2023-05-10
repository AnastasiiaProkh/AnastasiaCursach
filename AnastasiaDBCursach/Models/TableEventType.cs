using System;
using System.Collections.Generic;

namespace AnastasiaDBCursach.Models;

public partial class TableEventType
{
    public int Id { get; set; }

    public string? Etype { get; set; }

    public virtual ICollection<TableEvent> TableEvents { get; set; } = new List<TableEvent>();

    public virtual ICollection<TableTicket> TableTickets { get; set; } = new List<TableTicket>();
}
