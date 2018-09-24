namespace BikeStore.Data
{
    using BikeStore.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class BikeStoreDbContext : IdentityDbContext
    {
        public BikeStoreDbContext(DbContextOptions<BikeStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<BikeAd> Bikes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<User>()
                .HasMany(user => user.Bikes)
                .WithOne(bike => bike.Seller)
                .HasForeignKey(bike => bike.SellerId);

            base.OnModelCreating(builder);
        }
    }
}
