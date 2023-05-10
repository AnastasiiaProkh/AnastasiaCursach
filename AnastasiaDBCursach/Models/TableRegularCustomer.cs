using System;
using System.Collections.Generic;

namespace AnastasiaDBCursach.Models;

public partial class TableRegularCustomer
{
    public int Id { get; set; }

    public string? Rcname { get; set; }

    public DateTime? RcbirthDate { get; set; }

    public DateTime? RcdateOfIssue { get; set; }

    public string? Rccontacts { get; set; }

    public virtual ICollection<TableTicket> TableTickets { get; set; } = new List<TableTicket>();
}
