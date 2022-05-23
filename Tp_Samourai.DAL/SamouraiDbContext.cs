

using Microsoft.EntityFrameworkCore;
using Tp_Samourai.DAL.Entities;

namespace Tp_Samourai.DAL
{
    public class SamouraiDbContext : DbContext
    {
        public DbSet<Samourai> Samourai { get; set; }
       public DbSet<Arme> Armes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseSqlServer("Server=localhost;Database=SamouraiDB;User Id=sa;Password=Pa$$w0rd;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
