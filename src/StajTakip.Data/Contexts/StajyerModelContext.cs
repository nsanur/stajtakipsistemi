using Microsoft.EntityFrameworkCore;
using StajTakip.Data.Entities;
using StajTakip.Data.Migrations;

namespace StajTakip.Data.Contexts
{
    public class StajyerModelContext : DbContext
    {

        public StajyerModelContext(DbContextOptions<StajyerModelContext> options)
            : base (options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Stajyer>().ToTable("Stajyer");

            base.OnModelCreating(builder);
        }

        public DbSet<Stajyer> Stajyers { get; set; }
    }

}
