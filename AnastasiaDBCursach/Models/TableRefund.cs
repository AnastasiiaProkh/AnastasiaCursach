using System;
using System.Collections.Generic;

namespace AnastasiaDBCursach.Models;

public partial class TableRefund
{
    public int Id { get; set; }

    public int? TicketId { get; set; }

    public string? Rstatus { get; set; }

    public virtual TableTicket? Ticket { get; set; }
}
