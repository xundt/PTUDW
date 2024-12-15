using System;
using System.Collections.Generic;

namespace Trung_Tâm_Dạy_Trẻ.Models;

public partial class TblStudent
{
    public int StudentId { get; set; }

    public string? FullName { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? Address { get; set; }

    public int? Phone { get; set; }

    public string? Email { get; set; }

    public string? ParentName { get; set; }

    public int? ParentPhoneNumber { get; set; }

    public DateOnly? RegistrationDate { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<TblAttendance> TblAttendances { get; set; } = new List<TblAttendance>();

    public virtual ICollection<TblCourseEvaluation> TblCourseEvaluations { get; set; } = new List<TblCourseEvaluation>();

    public virtual ICollection<TblEventRegistration> TblEventRegistrations { get; set; } = new List<TblEventRegistration>();

    public virtual ICollection<TblTuition> TblTuitions { get; set; } = new List<TblTuition>();
}
