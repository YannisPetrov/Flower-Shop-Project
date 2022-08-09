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

        
    }
}