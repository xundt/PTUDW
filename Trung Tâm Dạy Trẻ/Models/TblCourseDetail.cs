using System;
using System.Collections.Generic;

namespace Trung_Tâm_Dạy_Trẻ.Models;

public partial class TblCourseDetail
{
    public int CourseDetailId { get; set; }

    public int? CourseId { get; set; }

    public int? WeekNumber { get; set; }

    public string? Topic { get; set; }

    public string? Materials { get; set; }

    public string? LearningObjectives { get; set; }

    public bool? IsActive { get; set; }

    public virtual TblCourse? Course { get; set; }
}
