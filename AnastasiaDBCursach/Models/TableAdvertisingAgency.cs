using System;
using System.Collections.Generic;

namespace AnastasiaDBCursach.Models;

public partial class TableAdvertisingAgency
{
    public int AgencyId { get; set; }

    public string? Aname { get; set; }

    public string? Aaddress { get; set; }

    public string? AbankAccountNumber { get; set; }

    public DateTime? AdateOfIssue { get; set; }

    public int? EventId { get; set; }

    public virtual TableEvent? Event { get; set; }
}
