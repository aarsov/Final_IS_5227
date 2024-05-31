using Microsoft.EntityFrameworkCore;
using Final_IS.Models;

namespace Final_IS.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(r => r.Model).IsRequired();
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasOne(g => g.Car);
                                  
         
            });
        }
    }
}
