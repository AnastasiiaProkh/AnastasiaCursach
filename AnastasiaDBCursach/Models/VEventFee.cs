using System;
using System.Collections.Generic;

namespace AnastasiaDBCursach.Models;

public partial class VEventFee
{
    public string? Name { get; set; }

    public string? Type { get; set; }

    public int? Fee { get; set; }

    public string? Status { get; set; }

    public DateTime? Date { get; set; }

    public TimeSpan? Time { get; set; }
}
