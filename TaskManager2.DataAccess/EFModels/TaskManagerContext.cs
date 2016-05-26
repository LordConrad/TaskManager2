namespace TaskManager2.DataAccess.EFModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext() : base("DefaultConnection")
        {
            //Database.SetInitializer(new DatabaseInitializer());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .HasRequired(x => x.TaskSender)
                .WithMany(m => m.SendedTasks)
                .HasForeignKey(f => f.SenderId)
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

            //modelBuilder.Entity<Task>()
            //    .HasRequired(x => x.TaskChief)
            //    .WithMany(m => m.ChiefTasks)
            //    .HasForeignKey(f => f.TaskChiefId)
            //    .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserProfile> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Priority> Priorities { get; set; }
    }
}
