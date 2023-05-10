using System;
using System.Collections.Generic;

namespace AnastasiaDBCursach.Models;

public partial class TableSponsor
{
    public int Id { get; set; }

    public string SponsorName { get; set; } = null!;

    public DateTime? SdateOfIssue { get; set; }

    public string SgeneralManagerName { get; set; } = null!;

    public string? Scontacts { get; set; }

    public string? SbankAccountNumber { get; set; }

    public virtual ICollection<TableEvent> TableEvents { get; set; } = new List<TableEvent>();
}
