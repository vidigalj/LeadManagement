using Microsoft.EntityFrameworkCore;

namespace LeadManagement.Infra.Context;

public abstract class BaseDbContext<TContext> : DbContext where TContext : DbContext
{
    protected BaseDbContext(DbContextOptions<TContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}

