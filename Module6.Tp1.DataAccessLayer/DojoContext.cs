namespace Module6.Tp1.DataAccessLayer
{
    using Microsoft.EntityFrameworkCore;
    using Module6.Tp1.DataAccessLayer.Entities;

    internal class DojoContext : DbContext
    {
        internal DbSet<Arme> Armes { get; set; }
        internal DbSet<Samourai> Samourais { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseSqlServer("Server=localhost;Database=DojoDb;User Id=sa;Password=Pa$$w0rd;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
