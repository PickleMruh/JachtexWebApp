using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace JachtexWebApp.Models
{
    public partial class DB_JachtexContext : DbContext
    {
        //public DB_JachtexContext(){}

        public DB_JachtexContext(DbContextOptions<DB_JachtexContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Jachty> Jachties { get; set; }
        public virtual DbSet<Klienci> Kliencis { get; set; }
        public virtual DbSet<Wypozyczenium> Wypozyczenia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Jachty>(entity =>
            {
                entity.HasKey(e => e.IdJacht)
                    .HasName("PK__Jachty__29926C8C22FBF973");

                entity.ToTable("Jachty");

                entity.Property(e => e.IdJacht).HasColumnName("id_jacht");

                entity.Property(e => e.DziennyKoszt).HasColumnName("dzienny_koszt");

                entity.Property(e => e.Kategoria)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("kategoria");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nazwa");

                entity.Property(e => e.Opis).HasColumnName("opis");
            });

            modelBuilder.Entity<Klienci>(entity =>
            {
                entity.HasKey(e => e.IdKlient)
                    .HasName("PK__Klienci__C6465E776DFC0F6B");

                entity.ToTable("Klienci");

                entity.Property(e => e.IdKlient).HasColumnName("id_klient");

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("imie");

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nazwisko");

                entity.Property(e => e.NrTel)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("nr_tel")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Wypozyczenium>(entity =>
            {
                entity.HasKey(e => e.IdWypo)
                    .HasName("PK__Wypozycz__6131015BCFABD76F");

                entity.Property(e => e.IdWypo).HasColumnName("id_wypo");

                entity.Property(e => e.IdJacht).HasColumnName("id_jacht");

                entity.Property(e => e.IdKlient).HasColumnName("id_klient");

                entity.Property(e => e.WypoKoniec)
                    .HasColumnType("date")
                    .HasColumnName("wypo_koniec");

                entity.Property(e => e.WypoStart)
                    .HasColumnType("date")
                    .HasColumnName("wypo_start");

                entity.HasOne(d => d.IdJachtNavigation)
                    .WithMany(p => p.Wypozyczenia)
                    .HasForeignKey(d => d.IdJacht)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Wypozycze__id_ja__3B75D760");

                entity.HasOne(d => d.IdKlientNavigation)
                    .WithMany(p => p.Wypozyczenia)
                    .HasForeignKey(d => d.IdKlient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Wypozycze__id_kl__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
