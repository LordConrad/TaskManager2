using System.Collections.Generic;
using System.Data.Entity;
using TaskManager.DataService.Database.DbModels;
using TaskManager.DataService.Models;
using Comment = TaskManager.DataService.Database.DbModels.Comment;

namespace TaskManager.DataService.Database
{
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext() : base("DefaultConnection")
        {
            System.Data.Entity.Database.SetInitializer(new CreateDatabaseIfNotExists<TaskManagerContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .HasRequired(x => x.TaskSender)
                .WithMany(x => x.SendedTasks)
                .HasForeignKey(x => x.SenderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Task>()
                .HasOptional(x => x.TaskRecipient)
                .WithMany(x => x.AssignedTasks)
                .HasForeignKey(x => x.RecipientId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Task>()
                .HasOptional(x => x.TaskPriority)
                .WithMany(x => x.SamePriorityTasks)
                .HasForeignKey(x => x.PriorityId)
                .WillCascadeOnDelete(false);
            
            //modelBuilder.Entity<ApplicationUser>()
            //    .HasMany(x => x.Comments)
            //    .WithRequired(x => x.Author)
            //    .HasForeignKey(x => x.CommentId)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comment>()
                .HasRequired(x => x.Task)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.TaskId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comment>()
                .HasRequired(x => x.Author)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.AuthorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaskEeventLog>()
                .HasRequired(x => x.Task)
                .WithMany(x => x.TaskEeventLogs)
                .HasForeignKey(x => x.TaskId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<TaskEeventLog>()
                .HasRequired(x => x.User)
                .WithMany(x => x.Logs)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(true);
            
            modelBuilder.Entity<ApplicationUserLogin>()
                .HasKey(x => x.UserId);

            modelBuilder.Entity<ApplicationUserRole>()
                .HasKey(x => x.UserId);
            
            modelBuilder.Entity<UserDetails>()
                .HasRequired(x => x.UserProfile)
                .WithOptional(x => x.UserDetails)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationRole>()
                .HasKey(x => x.Id);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
    }
}
