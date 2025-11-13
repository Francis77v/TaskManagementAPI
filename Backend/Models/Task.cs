using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Task
{
    public int Taskid { get; set; }

    public string Taskname { get; set; } = null!;

    public string? Taskdescription { get; set; }

    public int? Statusid { get; set; }

    public int Projectid { get; set; }

    public string? Assignedto { get; set; }

    public string Createdby { get; set; } = null!;

    public int? Parenttask { get; set; }

    public DateTime? DateModified { get; set; }

    public DateTime? DateCreated { get; set; }

    public virtual Users? AssignedtoNavigation { get; set; }

    public virtual Users CreatedbyNavigation { get; set; } = null!;

    public virtual ICollection<Task> InverseParenttaskNavigation { get; set; } = new List<Task>();

    public virtual Task? ParenttaskNavigation { get; set; }

    public virtual Project ProjectNavigation { get; set; } = null!;

    public virtual TaskStatus? StatusNavigation { get; set; }
    public virtual ICollection<Comment> CommentNavigation { get; set; } = new List<Comment>();
}
