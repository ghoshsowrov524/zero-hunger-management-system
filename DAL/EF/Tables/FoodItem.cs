using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class FoodItem
{
    public int Id { get; set; }

    public int CollectRequestId { get; set; }

    public string FoodName { get; set; } = null!;

    public decimal Qty { get; set; }

    public string Unit { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual CollectRequest CollectRequest { get; set; } = null!;
}
