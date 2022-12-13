using System;
using System.Collections.Generic;

namespace paycalc.core.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string Fullname { get; set; } = null!;

    public double BaseRate { get; set; }

    public virtual ICollection<Award> Awards { get; } = new List<Award>();

    public virtual ICollection<Week> Weeks { get; } = new List<Week>();
}
