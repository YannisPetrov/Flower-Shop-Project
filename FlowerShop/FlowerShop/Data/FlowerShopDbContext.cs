namespace FlowerShop.Data
{
    using FlowerShop.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class FlowerShopDbContext : IdentityDbContext<User>
    { 

        public FlowerShopDbContext(DbContextOptions<FlowerShopDbContext> options)
            : base(options)
        {
            
        }


        public DbSet<Flower> Flowers { get; init; }

        public DbSet<Cart> Carts { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder
                .Entity<Cart>()
                .HasKey(c => c.CartId);

            builder
                .Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany(u => u.Cart)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Cart>()
                .HasOne(c => c.Flower)
                .WithMany(f => f.Cart)
                .HasForeignKey(c => c.FlowerId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(builder);
        }

    }
}