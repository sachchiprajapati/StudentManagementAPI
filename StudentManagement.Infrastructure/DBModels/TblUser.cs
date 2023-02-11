using System;
using System.Collections.Generic;

namespace StudentManagement.Infrastructure.DBModels;

public partial class TblUser
{
    public int Id { get; set; }

    public int? UserType { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public DateTime? BirthDate { get; set; }

    public string? Gender { get; set; }

    public int? Standard { get; set; }

    public string? Address { get; set; }

    public string? Photo { get; set; }

    public string? FatherOccupation { get; set; }

    public string? MotherOcuupation { get; set; }

    public string? ContactNo { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual TblStandard? StandardNavigation { get; set; }

    public virtual TblUserType? UserTypeNavigation { get; set; }
}
