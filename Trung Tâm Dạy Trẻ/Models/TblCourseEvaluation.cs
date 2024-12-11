using System;
using System.Collections.Generic;

namespace Trung_Tâm_Dạy_Trẻ.Models;

public partial class TblCourseEvaluation
{
    public int EvaluationId { get; set; }

    public int? StudentId { get; set; }

    public int? CourseId { get; set; }

    public int? EvaluationScore { get; set; }

    public string? Comments { get; set; }

    public DateOnly? EvaluationDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual TblCourse? Course { get; set; }

    public virtual TblStudent? Student { get; set; }
}
