using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Distribution
{
    public int Id { get; set; }

    public int CollectRequestId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime DistributionDate { get; set; }

    public string Location { get; set; } = null!;

    public int BeneficiaryCount { get; set; }

    public string Remarks { get; set; } = null!;

    public virtual CollectRequest CollectRequest { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
