using System;
using System.Collections.Generic;

namespace Trung_Tâm_Dạy_Trẻ.Models;

public partial class TblEvent
{
    public int EventId { get; set; }

    public string? EventName { get; set; }

    public string? EventType { get; set; }

    public string? Description { get; set; }

    public DateOnly? StartDateTime { get; set; }

    public DateOnly? EndDateTime { get; set; }

    public string? Location { get; set; }

    public int? CurrentParticipants { get; set; }

    public int? MaxParticipants { get; set; }

    public string? Image { get; set; }

    public double? Fee { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<TblEventRegistration> TblEventRegistrations { get; set; } = new List<TblEventRegistration>();
}
