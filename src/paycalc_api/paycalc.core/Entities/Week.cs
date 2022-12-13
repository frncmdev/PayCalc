using System;
using System.Collections.Generic;

namespace paycalc.core.Entities;

public partial class Week
{
    public int WeekId { get; set; }

    public double? TotalPay { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<WorkDay> WorkDays { get; } = new List<WorkDay>();
}
