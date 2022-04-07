using House.Core.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace House.Data
{
    public class BuildingDbContext : DbContext

    {
        public BuildingDbContext()
        {
        }
        public BuildingDbContext(DbContextOptions<BuildingDbContext> options)
            : base(options) { }

        public DbSet<Building> Building { get; set; }

       
    }
}
