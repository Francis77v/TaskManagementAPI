using Backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task = Backend.Models.Task;
using TaskStatus = Backend.Models.TaskStatus;

namespace Backend.Context;

public partial class MyDbContext : IdentityDbContext<Users>
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
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ProjectTeam>()
            .HasKey(pt => new { pt.Userid, pt.Projectid });
        
        modelBuilder.Entity<ProjectTeam>()
            .HasOne(e => e.UserNavigation)
            .WithMany(e => e.UserTeams)
            .HasForeignKey(e => e.Userid)
            .IsRequired();
        modelBuilder.Entity<Task>()
            .HasOne(e => e.CreatorNavigation)
            .WithMany(e => e.TasksNav)
            .HasForeignKey(e => e.Createdby)
            .IsRequired();
        modelBuilder.Entity<Task>()
            .HasOne(e => e.AssignedtoNavigation)
            .WithMany(e => e.Tasks)
            .HasForeignKey(e => e.Assignedto)
            .IsRequired();
        modelBuilder.Entity<Task>()
            .HasOne(e => e.ProjectNavigation)
            .WithMany(e => e.Tasks)
            .HasForeignKey(e => e.Projectid)
            .IsRequired();
        modelBuilder.Entity<Comment>()
            .HasOne(e => e.CommentbyNavigation)
            .WithMany(e => e.Comments)
            .HasForeignKey(e => e.Commentby)
            .IsRequired();
        modelBuilder.Entity<ProjectTeam>()
            .HasOne(e => e.ProjectNavigation)
            .WithMany(e => e.ProjectTeams)
            .HasForeignKey(e => e.Projectid)
            .IsRequired();
        modelBuilder.Entity<Task>()
            .HasOne(e => e.StatusNavigation)
            .WithMany(e => e.Tasks)
            .HasForeignKey(e => e.Statusid)
            .IsRequired();
        modelBuilder.Entity<Task>()
            .HasOne(e => e.ParenttaskNavigation)
            .WithMany(e => e.InverseParenttaskNavigation)
            .HasForeignKey(e => e.Taskid)
            .IsRequired(false);
        modelBuilder.Entity<Comment>()
            .HasOne(e => e.CommentbyNavigation)
            .WithMany(e => e.Comments)
            .HasForeignKey(e => e.Commentby)
            .IsRequired();
        modelBuilder.Entity<Comment>()
            .HasOne(e => e.TaskNavigation)
            .WithMany(e => e.CommentNavigation)
            .HasForeignKey(e => e.Taskid)
            .IsRequired();

        UserSeeder.seedUsers(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
