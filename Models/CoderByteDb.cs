namespace CoderByte.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CoderByteDb : DbContext
    {
        public CoderByteDb()
            : base("name=CoderByteDb")
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Client_Products> Client_Products { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<User_Log> User_Log { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Client_Products>()
                .Property(e => e.Discount)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.MonthlyBasePrice)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Region>()
                .Property(e => e.Location)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Login)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.User_Log)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_Id);
        }
    }
}
