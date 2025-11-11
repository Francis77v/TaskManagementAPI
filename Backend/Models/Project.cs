using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Project
{
    public int Projectid { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? Datecreated { get; set; }

    public DateTime? Datemodified { get; set; }

    public virtual Users CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<ProjectTeam> ProjectTeams { get; set; } = new List<ProjectTeam>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
