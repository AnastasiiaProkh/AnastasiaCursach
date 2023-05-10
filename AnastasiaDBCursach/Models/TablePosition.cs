using System;
using System.Collections.Generic;

namespace AnastasiaDBCursach.Models;

public partial class TablePosition
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TableStaff> TableStaffs { get; set; } = new List<TableStaff>();
}
