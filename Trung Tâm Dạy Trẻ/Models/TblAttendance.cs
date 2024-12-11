using System;
using System.Collections.Generic;

namespace Trung_Tâm_Dạy_Trẻ.Models;

public partial class TblAttendance
{
    public int AttendanceId { get; set; }

    public int? StudenId { get; set; }

    public int? ClassId { get; set; }

    public DateOnly? AttendanceDay { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public virtual TblClass? Class { get; set; }

    public virtual TblStudent? Studen { get; set; }
}
