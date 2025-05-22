using Microsoft.EntityFrameworkCore;

namespace MPCalcHub.Infrastructure.Data;

public class ApplicationDBContext : DbContext
{ 
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
    }
}