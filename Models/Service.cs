using System;
using System.Collections.Generic;

namespace RadioCabs.Models;

public partial class Service
{
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public string VehicleType { get; set; } = null!;

    public string? Description { get; set; }

    public string AvailableCity { get; set; } = null!;

    public string FarePerKm { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;
}
