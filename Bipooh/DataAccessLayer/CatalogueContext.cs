using Bipooh.Models;
using Microsoft.EntityFrameworkCore;

namespace Bipooh.DataAccessLayer
{
    public class CatalogueContext : DbContext
    {
        public CatalogueContext(DbContextOptions<CatalogueContext> options)
       : base(options)
        {
        }


        public DbSet<Catalogue> CatalogueItems { get; set; } = null!;
        public DbSet<Student> StudentItems { get; set; } = null!;
        //public DbSet<Student> StudentItems => Set<Student>();
        public DbSet<Subject> SubjectItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            #region STUDENT
            modelBuilder.Entity<Student>(entity =>
            {

                entity.HasKey(e => e.Id);

                entity.ToTable("STUDENT");

                entity.Property(e => e.Id)
                    .HasPrecision(10)
                    .HasColumnName("ID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasPrecision(1)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasPrecision(1)
                    .HasColumnName("LAST_NAME");
            });
            #endregion

            #region CATALOGUE
            modelBuilder.Entity<Catalogue>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("CATALOGUE");

                entity.Property(e => e.Id)
                    .HasPrecision(10)
                    .HasColumnName("ID");

                entity.Property(e => e.NbAttendances)
                    .IsRequired()
                    .HasPrecision(1)
                    .HasColumnName("NbAttendances");

                entity.Property(e => e.NbAbsences)
                    .IsRequired()
                    .HasPrecision(1)
                    .HasColumnName("NbAbsences");
            });

            #endregion

            #region SUBJECT
            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("SUBJECT");

                entity.Property(e => e.Id)
                    .HasPrecision(10)
                    .HasColumnName("ID");

                entity.Property(e => e.DSCRP)
                    .IsRequired()
                    .HasPrecision(1)
                    .HasColumnName("DSCRP");

                entity.Property(e => e.Homework)
                    .IsRequired()
                    .HasPrecision(1)
                    .HasColumnName("HOMEWORK");

                entity.Property(e => e._inSchedule)
                    .IsRequired()
                    .HasPrecision(1)
                    .HasColumnName("IN_SCHEDULE");

            });
            #endregion
        }
    }
}
