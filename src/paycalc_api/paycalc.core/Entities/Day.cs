using System;
using System.Collections.Generic;

namespace paycalc.core.Entities;

public partial class Day
{
    public int DayId { get; set; }

    public string DayName { get; set; } = null!;
}
