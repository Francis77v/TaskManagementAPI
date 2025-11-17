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
    
    public virtual DbSet<Users> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectTeam>()
            .HasOne(e => e.UserNavigation)
            .WithMany(e => e.ProjectTeams)
            .HasForeignKey(e => e.Userid)
            .IsRequired();
        modelBuilder.Entity<Task>()
            .HasOne(e => e.CreatorNavigation)
            .WithMany(e => e.Tasks)
            .HasForeignKey(e => e.CreatorNavigation)
            .IsRequired();
        modelBuilder.Entity<Task>()
            .HasOne(e => e.AssignedtoNavigation)
            .WithMany(e => e.Tasks)
            .HasForeignKey(e => e.AssignedtoNavigation)
            .IsRequired();
        modelBuilder.Entity<Task>()
            .HasOne(e => e.ProjectNavigation)
            .WithMany(e => e.Tasks)
            .HasForeignKey(e => e.ProjectNavigation)
            .IsRequired();
        modelBuilder.Entity<Comment>()
            .HasOne(e => e.CommentbyNavigation)
            .WithMany(e => e.Comments)
            .HasForeignKey(e => e.CommentbyNavigation)
            .IsRequired();
        modelBuilder.Entity<ProjectTeam>()
            .HasOne(e => e.ProjectNavigation)
            .WithMany(e => e.ProjectTeams)
            .HasForeignKey(e => e.ProjectNavigation)
            .IsRequired();
        modelBuilder.Entity<Task>()
            .HasOne(e => e.StatusNavigation)
            .WithMany(e => e.Tasks)
            .HasForeignKey(e => e.StatusNavigation)
            .IsRequired();
        modelBuilder.Entity<Task>()
            .HasOne(e => e.ParenttaskNavigation)
            .WithMany(e => e.InverseParenttaskNavigation)
            .HasForeignKey(e => e.ParenttaskNavigation)
            .IsRequired(false);
        modelBuilder.Entity<Comment>()
            .HasOne(e => e.CommentbyNavigation)
            .WithMany(e => e.Comments)
            .HasForeignKey(e => e.CommentbyNavigation)
            .IsRequired();
        modelBuilder.Entity<Task>()
            .HasOne(e => e.CommentNavigation)
            .WithMany(e => e.)

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
