using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Comment
{
    public int Commentid { get; set; }

    public string Content { get; set; } = null!;

    public int Taskid { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public string Commentby { get; set; } = null!;

    public virtual Users CommentbyNavigation { get; set; } = null!;
    
    public virtual Task TaskNavigation { get; set; } = null!;
}
