using System;
using System.Collections.Generic;

namespace RadioCabs.Models;

public partial class Payment
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string PaymentFor { get; set; } = null!;

    public decimal Amount { get; set; }

    public string PaymentType { get; set; } = null!;

    public DateTime? PaymentDate { get; set; }

    public string? Status { get; set; }

    public virtual User User { get; set; } = null!;
}
