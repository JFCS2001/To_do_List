using Microsoft.EntityFrameworkCore;

namespace To_do_List.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Status_Task> Status_Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().HasKey(x => x.Id_Task);
            modelBuilder.Entity<Status_Task>().HasKey(x => x.Id_Status_Task);
        }
    }
}
