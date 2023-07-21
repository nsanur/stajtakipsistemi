using Microsoft.EntityFrameworkCore;
using StajTakip.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
            builder.Entity<Stajyer>().ToTable("stajyer");

            base.OnModelCreating(builder);
        }

        public DbSet<Stajyer> Stajyers { get; set; }

    }
}
