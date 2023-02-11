using System;
using System.Collections.Generic;

namespace StudentManagement.Infrastructure.DBModels;

public partial class TblStandard
{
    public int Id { get; set; }

    public string? Standard { get; set; }

    public virtual ICollection<TblUser> TblUsers { get; } = new List<TblUser>();
}
