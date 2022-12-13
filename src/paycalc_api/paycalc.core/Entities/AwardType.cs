using System;
using System.Collections.Generic;

namespace paycalc.core.Entities;

public partial class AwardType
{
    public int AwardTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Award> Awards { get; } = new List<Award>();
}
