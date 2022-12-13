using System;
using System.Collections.Generic;

namespace paycalc.core.Entities;

public partial class Award
{
    public int AwardId { get; set; }

    public double Multiplier { get; set; }

    public int? AwardTypeId { get; set; }

    public int? UserId { get; set; }

    public virtual AwardType? AwardType { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<WorkDay> WorkDays { get; } = new List<WorkDay>();
}
