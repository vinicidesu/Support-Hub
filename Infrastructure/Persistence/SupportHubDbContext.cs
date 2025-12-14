using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence
{
    public class SupportHubDbContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }


        public SupportHubDbContext(DbContextOptions<SupportHubDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SupportHubDbContext).Assembly);
        }
    }
}
