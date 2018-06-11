namespace assignment1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CameraCompaniesModel : DbContext
    {
        public CameraCompaniesModel()
            : base("name=CameraCompaniesModel")
        {
        }

        public virtual DbSet<camera> cameras { get; set; }
        public virtual DbSet<company> companies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<camera>()
                .Property(e => e.Model)
                .IsUnicode(false);

            modelBuilder.Entity<camera>()
                .Property(e => e.cameraPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<camera>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<company>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<company>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<company>()
                .Property(e => e.Logo)
                .IsUnicode(false);

            modelBuilder.Entity<company>()
                .Property(e => e.CEO)
                .IsUnicode(false);

            modelBuilder.Entity<company>()
                .Property(e => e.stockName)
                .IsUnicode(false);

            modelBuilder.Entity<company>()
                .HasMany(e => e.cameras)
                .WithRequired(e => e.company)
                .WillCascadeOnDelete(false);
        }
    }
}
