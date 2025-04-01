using LeadManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.Infra.Context;

public class LeadDbContext : BaseDbContext<LeadDbContext>
{
    public LeadDbContext(DbContextOptions<LeadDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;
    }

    public DbSet<Lead> Leads { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
