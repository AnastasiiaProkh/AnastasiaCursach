using System;
using System.Collections.Generic;

namespace AnastasiaDBCursach.Models;

public partial class TableGiftTicket
{
    public int GiftTicketId { get; set; }

    public int? TicketId { get; set; }

    public decimal? Tprice { get; set; }

    public DateTime? TdateOfPurchase { get; set; }

    public virtual TableTicket? Ticket { get; set; }
}
