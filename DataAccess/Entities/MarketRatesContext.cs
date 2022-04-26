using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Entities
{
    public partial class MarketRatesContext : DbContext
    {
        public MarketRatesContext()
        {
        }

        public MarketRatesContext(DbContextOptions<MarketRatesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<CurrencyQuote> CurrencyQuote { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=MarketRates;Integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ProviderLastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CurrencyQuote>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.ProviderLastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
