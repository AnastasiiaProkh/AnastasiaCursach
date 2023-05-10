using System;
using System.Collections.Generic;

namespace AnastasiaDBCursach.Models;

public partial class TableInvitation
{
    public int Id { get; set; }

    public string? Iname { get; set; }

    public int? EventId { get; set; }

    public string? Istatus { get; set; }

    public int? Ifee { get; set; }

    public string? Irider { get; set; }

    public string? Icontacts { get; set; }

    public string? IbankAccountNumber { get; set; }

    public virtual TableEvent? Event { get; set; }
}
