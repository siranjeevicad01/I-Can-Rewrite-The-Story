using Microsoft.EntityFrameworkCore;

namespace I_Can_Rewrite_The_Story 
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Define your database tables as DbSet properties here
        
        public DbSet<RegisterModel> Usr_Reg { get; set; }

        // Optionally, you can override the OnModelCreating method to configure the model
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);
        //
        //     // Configure your entity relationships, indexes, etc. here
        // }

        // Add additional DbSet properties for each entity in your database
        // Example:
        // public DbSet<Order> Orders { get; set; }
    }
}
