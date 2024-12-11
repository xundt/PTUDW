using System;
using System.Collections.Generic;

namespace Trung_Tâm_Dạy_Trẻ.Models;

public partial class TblTuition
{
    public int TuitionId { get; set; }

    public int? StudenId { get; set; }

    public int? ClassId { get; set; }

    public double? Amount { get; set; }

    public DateOnly? AutumnDay { get; set; }

    public DateOnly? Deadline { get; set; }

    public string? PaymentMethod { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public virtual TblClass? Class { get; set; }

    public virtual TblStudent? Studen { get; set; }
}
