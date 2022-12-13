using System;
using System.Collections.Generic;

namespace paycalc.core.DTO;

public partial class AwardDTO
{
    public double Multiplier { get; set; }
    public int? AwardTypeId { get; set; }
    public virtual AwardTypeDTO? AwardType { get; set; }
}
