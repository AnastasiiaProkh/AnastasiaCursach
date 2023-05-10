using System;
using System.Collections.Generic;

namespace AnastasiaDBCursach.Models;

public partial class TableTicket
{
    public int Id { get; set; }

    public int EventId { get; set; }

    public int Etype { get; set; }

    public int Ttype { get; set; }

    public int? Trow { get; set; }

    public int? Tseat { get; set; }

    public string? Tsector { get; set; }

    public decimal? Tprice { get; set; }

    public int? RcustomerId { get; set; }

    public DateTime? TdateOfPurchase { get; set; }

    public int? StaffId { get; set; }

    public virtual TableEventType EtypeNavigation { get; set; } = null!;

    public virtual TableEvent Event { get; set; } = null!;

    public virtual TableRegularCustomer? Rcustomer { get; set; }

    public virtual TableStaff? Staff { get; set; }

    public virtual ICollection<TableGiftTicket> TableGiftTickets { get; set; } = new List<TableGiftTicket>();

    public virtual ICollection<TableRefund> TableRefunds { get; set; } = new List<TableRefund>();

    public virtual TableTicketType TtypeNavigation { get; set; } = null!;
}
