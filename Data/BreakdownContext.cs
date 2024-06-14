using Microsoft.EntityFrameworkCore;
using RNR_WebAPI.Model;

namespace RNR_WebAPI.Data
{
    public class BreakdownContext : DbContext
    {
        public BreakdownContext(DbContextOptions<BreakdownContext> options) : base(options) { }

        public DbSet<Breakdown> Breakdowns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Breakdown>()
                .HasKey(b => b.BreakdownReference);
        }
    }
}
