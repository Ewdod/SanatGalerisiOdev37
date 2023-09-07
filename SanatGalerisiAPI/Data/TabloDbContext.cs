using Microsoft.EntityFrameworkCore;

namespace SanatGalerisiAPI.Data
{
    public class TabloDbContext : DbContext
    {

        public TabloDbContext(DbContextOptions<TabloDbContext> options) : base(options)
        {
        }

        public DbSet<Tablo> Tablolar => Set<Tablo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tablo>().ToTable("Tablolar");
            modelBuilder.Entity<Tablo>().HasData(
            new Tablo { Id = 1, RessamAdi = "Ressam1", ResminYapilmaTarihi = new DateTime(2022, 1, 15) },
            new Tablo { Id = 2, RessamAdi = "Ressam2", ResminYapilmaTarihi = new DateTime(2021, 7, 10) });
        }

    }
}
