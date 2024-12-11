using System;
using System.Collections.Generic;

namespace Trung_Tâm_Dạy_Trẻ.Models;

public partial class TblClass
{
    public int ClassId { get; set; }

    public int? TeacherId { get; set; }

    public string? NameClass { get; set; }

    public int? Quantity { get; set; }

    public string? Classroom { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public double? Tuition { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<TblAttendance> TblAttendances { get; set; } = new List<TblAttendance>();

    public virtual ICollection<TblTuition> TblTuitions { get; set; } = new List<TblTuition>();

    public virtual TblTeacher? Teacher { get; set; }
}
