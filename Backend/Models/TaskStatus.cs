using System;
using System.Collections.Generic;
using Backend.Models.enums;

namespace Backend.Models;

public partial class TaskStatus
{
    public int TaskStatusid { get; set; }
    public Status status { get; set; }
    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
    
}
