using System;
using System.Collections.Generic;

namespace AnastasiaDBCursach.Models;

public partial class VGiftTicket
{
    public int Id { get; set; }

    public decimal? Price { get; set; }

    public string? Customer { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public DateTime? Date { get; set; }

    public TimeSpan? Time { get; set; }
}
