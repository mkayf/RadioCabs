using System;
using System.Collections.Generic;

namespace RadioCabs.Models;

public partial class Feedback
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public string? City { get; set; }

    public string Type { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }
}
