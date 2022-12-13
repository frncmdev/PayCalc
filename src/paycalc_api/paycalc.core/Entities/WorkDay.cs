using System;
using System.Collections.Generic;

namespace paycalc.core.Entities;

public partial class WorkDay
{
    public int WordDayId { get; set; }

    public double? BaseHours { get; set; }

    public double? AwardHours { get; set; }

    public int WeekId { get; set; }

    public int AwardId { get; set; }

    public virtual Award Award { get; set; } = null!;

    public virtual Week Week { get; set; } = null!;
}
