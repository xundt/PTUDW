using System;
using System.Collections.Generic;

namespace Trung_Tâm_Dạy_Trẻ.Models;

public partial class TblCourse
{
    public int CourseId { get; set; }

    public int? TeacherId { get; set; }

    public string? CourseName { get; set; }

    public string? Description { get; set; }

    public string? CourseType { get; set; }

    public string? AgeGroup { get; set; }

    public int? Duration { get; set; }

    public double? Tuition { get; set; }

    public int? MaxStudents { get; set; }

    public int? MainContent { get; set; }

    public string? RegistrationRequirements { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<TblCourseDetail> TblCourseDetails { get; set; } = new List<TblCourseDetail>();

    public virtual ICollection<TblCourseEvaluation> TblCourseEvaluations { get; set; } = new List<TblCourseEvaluation>();

    public virtual TblTeacher? Teacher { get; set; }
}
