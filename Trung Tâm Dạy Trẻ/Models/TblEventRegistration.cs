using System;
using System.Collections.Generic;

namespace Trung_Tâm_Dạy_Trẻ.Models;

public partial class TblEventRegistration
{
    public int EventRegistrationId { get; set; }

    public int? StudentId { get; set; }

    public int? EventId { get; set; }

    public DateOnly? RegistrationDate { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public virtual TblEvent? Event { get; set; }

    public virtual TblStudent? Student { get; set; }
}
