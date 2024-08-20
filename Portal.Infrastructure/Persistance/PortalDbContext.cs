
using Microsoft.EntityFrameworkCore;
using Portal.Domain.Entities;

namespace Portal.Infrastructure.Persistance
{
    public class PortalDbContext : DbContext
    {
        public PortalDbContext(DbContextOptions<PortalDbContext> options) : base(options) {}

        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vacancy>()
                .HasOne(v => v.Category)
                .WithMany(c => c.Vacancies)
                .HasForeignKey(c => c.CategoryId);
        }
    }
}