using System;
using System.Collections.Generic;

namespace StudentManagement.Infrastructure.DBModels;

public partial class TblUserType
{
    public int Id { get; set; }

    public string? UserType { get; set; }

    public virtual ICollection<TblUser> TblUsers { get; } = new List<TblUser>();
}
