using System;
using System.Collections.Generic;
using Backend.Models.enums;

namespace Backend.Models;

public partial class ProjectTeam
{
    public int Teamid { get; set; }

    public string Userid { get; set; } = null!;

    public int Projectid { get; set; }
    public Role role { get; set; } 
    public virtual Project ProjectNavigation { get; set; } = null!;
    public virtual Users UserNavigation { get; set; } = null!;
}
