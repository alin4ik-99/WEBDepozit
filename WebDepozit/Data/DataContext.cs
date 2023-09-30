using Microsoft.EntityFrameworkCore;
using WebDepozit.Models;

namespace WebDepozit.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
           // Database.EnsureDeleted();
            Database.EnsureCreated();

        }

        public DbSet<MounthlyDepozitReport> MounthlyDepozitReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MounthlyDepozitReport>().Property(x => x.MounthId).ValueGeneratedOnAdd();
        }
    }
}
