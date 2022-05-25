namespace Module6.Tp1.DataAccessLayer
{
    using Microsoft.EntityFrameworkCore;
    using Module6.Tp1.DataAccessLayer.Entities;
    using Module6.Tp1.DataAccessLayer.Entities.Abstractions;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class DojoContext : DbContext
    {
        internal DbSet<Arme> Armes { get; set; }
        internal DbSet<Samourai> Samourais { get; set; }
        internal DbSet<ArtMartial> ArtMartiaux { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseSqlServer("Server=localhost;Database=DojoDb;User Id=sa;Password=Pa$$w0rd;");
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
