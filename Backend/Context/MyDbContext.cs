using System;
using System.Collections.Generic;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Task = Backend.Models.Task;
using TaskStatus = Backend.Models.TaskStatus;

namespace Backend.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }
    
    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectTeam> ProjectTeams { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TaskStatus> TaskStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
