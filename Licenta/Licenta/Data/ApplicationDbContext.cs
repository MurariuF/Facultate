using System;
using System.Collections.Generic;
using System.Text;
using Licenta.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Licenta.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Detalii> Detaliis { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                .HasMany(d => d.Detaliis)
                .WithOne(u => u.User)
                .IsRequired();

            base.OnModelCreating(builder);
        }

    }
}
