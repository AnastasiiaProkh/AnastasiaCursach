using System;
using System.Collections.Generic;

namespace AnastasiaDBCursach.Models;

public partial class TableEvent
{
    public int Id { get; set; }

    public string? Ename { get; set; }

    public int? Etype { get; set; }

    public DateTime? Edate { get; set; }

    public TimeSpan? Etime { get; set; }

    public int? SponsorId { get; set; }

    public virtual TableEventType? EtypeNavigation { get; set; }

    public virtual TableSponsor? Sponsor { get; set; }

    public virtual ICollection<TableAdvertisingAgency> TableAdvertisingAgencies { get; set; } = new List<TableAdvertisingAgency>();

    public virtual ICollection<TableInvitation> TableInvitations { get; set; } = new List<TableInvitation>();

    public virtual ICollection<TableRescheduledEvent> TableRescheduledEvents { get; set; } = new List<TableRescheduledEvent>();

    public virtual ICollection<TableTicket> TableTickets { get; set; } = new List<TableTicket>();
}
