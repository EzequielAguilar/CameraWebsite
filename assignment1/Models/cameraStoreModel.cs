namespace assignment1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class cameraStoreModel : DbContext
    {
        public cameraStoreModel()
            : base("name=cameraStoreModel")
        {
        }

        public virtual DbSet<camera> cameras { get; set; }
        public virtual DbSet<company> companies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<camera>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<camera>()
                .Property(e => e.cameraPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<company>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<company>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<company>()
                .Property(e => e.Value)
                .HasPrecision(19, 4);
        }
    }
}
