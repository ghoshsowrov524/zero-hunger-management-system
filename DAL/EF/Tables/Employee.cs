using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public DateOnly JoiningDate { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<CollectRequest> CollectRequests { get; set; } = new List<CollectRequest>();

    public virtual ICollection<Distribution> Distributions { get; set; } = new List<Distribution>();
}
