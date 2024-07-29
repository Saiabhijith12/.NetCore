using Microsoft.EntityFrameworkCore;

namespace User_api.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => new { u.user_name });
            modelBuilder.Entity<User>()
               .Property(u => u.user_status)
               .HasMaxLength(1)
               .HasColumnType("varchar(1)");
        }
    }
}
