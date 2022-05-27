using Domotics.DataAccessLayer.Entities;
using Domotics.DataAccessLayer.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domotics.DataAccessLayer
{
    public class DomoticsContext : DbContext
    {
        public DbSet<Measure> Measures { get; set; }
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseSqlServer("Server=localhost;Database=DomoticsDB;User Id=sa;Password=Pa$$w0rd;");
            base.OnConfiguring(optionsBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
        .Entries()
        .Where(e => e.Entity is ADataObject && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((ADataObject)entityEntry.Entity).LastModifiedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((ADataObject)entityEntry.Entity).CreationDate = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
