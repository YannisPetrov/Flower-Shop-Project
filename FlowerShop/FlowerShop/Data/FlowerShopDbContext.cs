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

        public DbSet<Orders> Orders { get; init; }

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
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Entity<Cart>()
                .HasOne(c => c.Flower)
                .WithMany(f => f.Cart)
                .HasForeignKey(c => c.FlowerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Entity<Orders>()
                .HasKey(o => o.OrderId);

            builder
                .Entity<Orders>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(c => c.UserId);

            builder
                .Entity<Flower>().HasData(
                 new Flower
                 {
                     Id = 1,
                     FlowerName = "Pink Dahlia",
                     FlowerPrice = 5.99,
                     ImageURL = "https://keyassets.timeincuk.net/inspirewp/live/wp-content/uploads/sites/8/2020/10/GettyImages-1167560383_413205512_747927761.jpg"
                 },
                 new Flower
                 {
                     Id = 2,
                     FlowerName = "Purple Hyacinthus",
                     FlowerPrice = 2.39,
                     ImageURL = "https://upload.wikimedia.org/wikipedia/commons/7/7e/Hyacinth_-_Anglesey_Abbey.jpg"
                 },
                 new Flower
                 {
                     Id = 3,
                     FlowerName = "Pink Rose",
                     FlowerPrice = 5.69,
                     ImageURL = "https://upload.wikimedia.org/wikipedia/commons/7/77/Pink_rose_.JPG"
                 },
                 new Flower
                 {
                     Id = 4,
                     FlowerName = "Fire Tulip",
                     FlowerPrice = 4.55,
                     ImageURL = "https://cdn.britannica.com/37/227037-050-CA792866/Broken-tulip-flower.jpg"
                 },
                 new Flower
                 {
                     Id = 5,
                     FlowerName = "Red Alstromeria",
                     FlowerPrice = 2.33,
                     ImageURL = "https://cdn.shopify.com/s/files/1/1116/9522/products/BLALSTRD50_A_1024x1024.jpg?v=1569156223"
                 },
                 new Flower
                 {
                     Id = 6,
                     FlowerName = "Orange Gerbera",
                     FlowerPrice = 2.59,
                     ImageURL = "https://www.gardeningknowhow.com/wp-content/uploads/2012/03/gerbera.jpg"
                 },
                 new Flower
                 {
                     Id = 7,
                     FlowerName = "Purple Lilium",
                     FlowerPrice = 12.99,
                     ImageURL = "https://cdn.shopify.com/s/files/1/0512/7477/6770/products/lilypurpleeyePURPLEDREAMCC_1024x1024.jpg?v=1616793109"
                 },
                 new Flower
                 {
                     Id = 8,
                     FlowerName = "Pink Orchid",
                     FlowerPrice = 13,
                     ImageURL = "https://img.freepik.com/free-photo/pink-phalaenopsis-orchid-flower_1373-561.jpg?w=2000"
                 },
                 new Flower
                 {
                     Id = 9,
                     FlowerName = "Pink Lotus",
                     FlowerPrice = 15.99,
                     ImageURL = "https://images.unsplash.com/photo-1616435577207-ca90abc6b732?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8bG90dXMlMjBmbG93ZXJ8ZW58MHx8MHx8&w=1000&q=80"
                 },
                 new Flower
                 {
                     Id = 10,
                     FlowerName = "Sunflower",
                     FlowerPrice = 2,
                     ImageURL = "https://cdn.apartmenttherapy.info/image/upload/f_jpg,q_auto:eco,c_fill,g_auto,w_1500,ar_1:1/stock%2FGettyImages-1312066960-cropped"
                 },
                 new Flower
                 {
                     Id = 11,
                     FlowerName = "Dried Lavander",
                     FlowerPrice = 3.55,
                     ImageURL = "https://m.media-amazon.com/images/W/WEBP_402378-T1/images/I/81ZVx7QvwwL._AC_SX679_.jpg"
                 },
                 new Flower
                 {
                     Id = 12,
                     FlowerName = "Pink Zinnia",
                     FlowerPrice = 6.25,
                     ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6e/Zinnienbl%C3%BCte_Zinnia_elegans_stack15_20190722-RM-7222254.jpg/1280px-Zinnienbl%C3%BCte_Zinnia_elegans_stack15_20190722-RM-7222254.jpg"
                 },
                 new Flower
                 {
                     Id = 13,
                     FlowerName = "Daffodil",
                     FlowerPrice = 1.59,
                     ImageURL = "https://www.thespruce.com/thmb/G9evkIXztZcAoEcnpi-xIo0U4oU=/2656x2656/smart/filters:no_upscale()/planting-and-growing-daffodils-1402136_01-bb8eada2ffb4443dbb20a7b1f0f3dfce.jpg"
                 },
                 new Flower
                 {
                     Id = 14,
                     FlowerName = "Bluebell",
                     FlowerPrice = 1.55,
                     ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a8/Hyacinthoides_non-scripta_%28Common_Bluebell%29.jpg/1200px-Hyacinthoides_non-scripta_%28Common_Bluebell%29.jpg"
                 },
                 new Flower
                 {
                     Id = 15,
                     FlowerName = "Pink Peony",
                     FlowerPrice = 6.98,
                     ImageURL = "https://mitchellsnursery.com/wp-content/uploads/2022/01/image.jpeg"
                 },
                 new Flower
                 {
                     Id = 16,
                     FlowerName = "Purple Aster",
                     FlowerPrice = 3.99,
                     ImageURL = "https://www.lovingly.com/wp-content/uploads/2021/07/AdobeStock_222030786-683x1024.jpeg"
                 },
                 new Flower
                 {
                     Id = 17,
                     FlowerName = "Orange Calendula",
                     FlowerPrice = 4.75,
                     ImageURL = "https://upload.wikimedia.org/wikipedia/commons/a/a7/Pot_marigold.jpg"
                 },
                 new Flower
                 {
                    Id = 18,
                    FlowerName = "Pink Carnation",
                    FlowerPrice = 5.99,
                    ImageURL = "https://images.immediate.co.uk/production/volatile/sites/18/2021/07/JI_190620_PerpetualCarnations_003-30143f4.jpg"
                 });


            base.OnModelCreating(builder);
        }

    }
}