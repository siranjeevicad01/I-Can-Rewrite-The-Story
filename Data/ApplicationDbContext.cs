using Microsoft.EntityFrameworkCore;

namespace I_Can_Rewrite_The_Story.Models 
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRegistration>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }

        
        // DbSet for UserRegistration entity
        public DbSet<UserRegistration> UserRegistrations { get; set; }

        public DbSet<UserRegistration> Users { get; set; }


        // DbSet for LoginModel entity
        public DbSet<LoginModel> Login { get; set; }
    }
}
