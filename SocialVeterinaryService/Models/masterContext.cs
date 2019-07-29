using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SocialVeterinaryService.Models
{
    public partial class masterContext : DbContext
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnimalType> AnimalType { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Pets> Pets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AnimalType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK__tmp_ms_x__516F03B5310DB99E");

                entity.Property(e => e.TypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.LastName).HasMaxLength(150);

                entity.Property(e => e.Miemployee).HasColumnName("MIEmployee");

                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<Pets>(entity =>
            {
                entity.HasKey(e => e.PetId)
                    .HasName("PK__tmp_ms_x__48E5386272AC1462");

                entity.Property(e => e.PetName).HasMaxLength(50);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_Pets_ToPerson");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Pets_ToAnimalType");
            });
        }
    }
}
