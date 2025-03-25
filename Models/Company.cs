using System;
using System.Collections.Generic;

namespace RadioCabs.Models;

public partial class Company
{
    public int Id { get; set; }

    public string CompanyName { get; set; } = null!;

    public string CompanyId { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? ContactPerson { get; set; }

    public string? Designation { get; set; }

    public string? Address { get; set; }

    public string? Mobile { get; set; }

    public string? Telephone { get; set; }

    public string? Fax { get; set; }

    public string Email { get; set; } = null!;

    public string MembershipType { get; set; } = null!;

    public string PaymentType { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
