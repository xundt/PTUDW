using System;
using System.Collections.Generic;

namespace Trung_Tâm_Dạy_Trẻ.Models;

public partial class TblTeacher
{
    public int TeacherId { get; set; }

    public string? TeacherName { get; set; }

    public string? Expertise { get; set; }

    public string? Experience { get; set; }

    public string? Certificate { get; set; }

    public string? Image { get; set; }

    public string? TeachingAssignment { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<TblClass> TblClasses { get; set; } = new List<TblClass>();

    public virtual ICollection<TblCourse> TblCourses { get; set; } = new List<TblCourse>();
}
