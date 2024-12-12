using System;
using System.Collections.Generic;

namespace Trung_Tâm_Dạy_Trẻ.Models;

public partial class TblMenu
{
    public int MenuId { get; set; }

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public int? Description { get; set; }

    public int? ParentId { get; set; }

    public int? Position { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateOnly? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsActive { get; set; }
}
