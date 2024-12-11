using System;
using System.Collections.Generic;

namespace Trung_Tâm_Dạy_Trẻ.Models;

public partial class TblFinancialTransaction
{
    public int TransactionId { get; set; }

    public string? Type { get; set; }

    public double? Amount { get; set; }

    public DateOnly? TransactionDate { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }
}
