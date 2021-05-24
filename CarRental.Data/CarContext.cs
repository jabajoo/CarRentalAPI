using CarRental.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Data
{
    public partial class CarContext: DbContext
    {
        public CarContext(){}
        public CarContext(DbContextOptions<CarContext> options)
            : base(options){}

        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.RegistrationPlate)
                    .IsRequired();
                entity.HasKey(e => new { e.RegistrationPlate });
                
                entity.HasOne(c=>c.Category)
                .WithMany(cc=> cc.Cars)
                .HasForeignKey(c=>c.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => new { e.BookingNumber });

                entity.Property(e => e.BookingNumber).IsRequired();

                entity.HasOne(b => b.Car)
                    .WithMany(c => c.Bookings)
                    .HasForeignKey(b => b.CarRegistrationPlate)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.Property(e => e.Price).HasPrecision(10,2);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => new { e.Id });

                entity.Property(e => e.Id).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}