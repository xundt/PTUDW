﻿using System;
using System.Collections.Generic;

namespace Trung_Tâm_Dạy_Trẻ.Models;

public partial class TblRole
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<TblAccount> TblAccounts { get; set; } = new List<TblAccount>();
}
