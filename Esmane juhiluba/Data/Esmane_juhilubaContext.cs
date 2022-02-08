using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Esmane_juhiluba.Models;

namespace Esmane_juhiluba.Data
{
    public class Esmane_juhilubaContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Eksam>()
                .HasIndex(e => new { e.Eesnimi, e.Perenimi })
                .IsUnique();
        }

        public Esmane_juhilubaContext (DbContextOptions<Esmane_juhilubaContext> options)
            : base(options)
        {
        }

        public DbSet<Eksam> Eksam { get; set; }
    }
}
