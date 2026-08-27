using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class CollectRequest
{
    public int Id { get; set; }

    public int RestaurantId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime RequestDate { get; set; }

    public DateTime MaximumPreserveTime { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? CollectedDate { get; set; }

    public DateTime? CompletedDate { get; set; }

    public virtual ICollection<Distribution> Distributions { get; set; } = new List<Distribution>();

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<FoodItem> FoodItems { get; set; } = new List<FoodItem>();

    public virtual Restaurant Restaurant { get; set; } = null!;
}
