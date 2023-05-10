using System;
using System.Collections.Generic;

namespace AnastasiaDBCursach.Models;

public partial class TableRescheduledEvent
{
    public int Id { get; set; }

    public int? EventId { get; set; }

    public string? Status { get; set; }

    public TimeSpan? NewTime { get; set; }

    public DateTime? NewDate { get; set; }

    public virtual TableEvent? Event { get; set; }
}
