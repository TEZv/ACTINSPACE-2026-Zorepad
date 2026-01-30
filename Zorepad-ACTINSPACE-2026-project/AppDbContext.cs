using Microsoft.EntityFrameworkCore;
using Zorepad_ACTINSPACE_2026_project.Entities;

namespace Zorepad_ACTINSPACE_2026_project;



public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    public DbSet<GeoData> GeoDatas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("postgis");
        
        base.OnModelCreating(modelBuilder);

        /*modelBuilder.Entity<GeoData>(geodata =>
        {
            
        });*/
    }
}