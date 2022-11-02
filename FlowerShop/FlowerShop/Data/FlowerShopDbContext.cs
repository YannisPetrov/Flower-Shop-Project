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
        public DbSet<Address> Addresses { get; init; }

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
                .HasForeignKey(o => o.UserId);

            builder
                .Entity<Address>()
                .HasOne(a => a.User)
                .WithMany(u => u.Addresses)
                .HasForeignKey(a => a.UserId);

            builder
                .Entity<Flower>().HasData(
                 new Flower
                 {
                     Id = 1,
                     FlowerName = "Pink Dahlia",
                     FlowerPrice = 5.99,
                     ImageURL = "https://keyassets.timeincuk.net/inspirewp/live/wp-content/uploads/sites/8/2020/10/GettyImages-1167560383_413205512_747927761.jpg",
                     Info = "Pink dahlias symbolize kindness and beauty. These flowers also symbolize feminine beauty, which makes them a great gift for any special lady in your life. And they're perfect for Mothers' Day! Dahlias are the official birth flower for August, although other traditions recognize them as the November birth month flower instead.Dahlia flowers hold different symbolism depending on their colors.Generally,these summer - blooming and vivid flowers symbolize elegance,inner strength,change,creativity,and dignity.Though most of the symbolism is positive,dahlias still carry a few negative connotations,including betrayal,dishonesty,and instability. "
                 },
                 new Flower
                 {
                     Id = 2,
                     FlowerName = "Purple Hyacinthus",
                     FlowerPrice = 2.39,
                     ImageURL = "https://upload.wikimedia.org/wikipedia/commons/7/7e/Hyacinth_-_Anglesey_Abbey.jpg",
                     Info = "The hyacinth is the flower of the sun god Apollo and is a symbol of peace, commitment and beauty, but also of power and pride. The hyacinth is often found in Christian churches as a symbol of happiness and love. If someone gives you a Purple Hyacinth they want to show sorrow and they ask for forgiveness"
                 },
                 new Flower
                 {
                     Id = 3,
                     FlowerName = "Pink Rose",
                     FlowerPrice = 5.69,
                     ImageURL = "https://upload.wikimedia.org/wikipedia/commons/7/77/Pink_rose_.JPG",
                     Info = "A light rosy tone is often associated with femininity, so, naturally, the pink rose meaning is that of grace and sweetness. Other interpretations include gentleness, appreciation, joy, thankfulness, and elegance. The variety of meanings make giving pink roses appropriate for so many occasions."
                 },
                 new Flower
                 {
                     Id = 4,
                     FlowerName = "Fire Tulip",
                     FlowerPrice = 4.55,
                     ImageURL = "https://cdn.britannica.com/37/227037-050-CA792866/Broken-tulip-flower.jpg",
                     Info = "There isn't a great meaning behind this flower. It is simply beautiful and prized for it's uniqueness"
                 },
                 new Flower
                 {
                     Id = 5,
                     FlowerName = "Red Alstromeria",
                     FlowerPrice = 2.33,
                     ImageURL = "https://cdn.shopify.com/s/files/1/1116/9522/products/BLALSTRD50_A_1024x1024.jpg?v=1569156223",
                     Info = "The alstroemeria flower has an array of meanings depending on the colour. But the beautiful blooms always connect to a similar meaning of friendship, love, strength and devotion. This alstroemeria colour represents passion. It's a fun way to say 'I love you' without red roses!"
                 },
                 new Flower
                 {
                     Id = 6,
                     FlowerName = "Orange Gerbera",
                     FlowerPrice = 2.59,
                     ImageURL = "https://www.gardeningknowhow.com/wp-content/uploads/2012/03/gerbera.jpg",
                     Info = "The gerbera has different meanings to different cultures. The Egyptians believed that they symbolised a closeness to nature and a devotion to the sun, whereas the Celts thought they lessened the sorrows and stresses of everyday life. Generally, gerberas symbolise innocence, purity, cheerfulness and loyal love. Orange gerberas represent happiness, joy, friendship, and warmth, which make these alluring blooms the perfect gifting flower for your friends and colleagues."
                 },
                 new Flower
                 {
                     Id = 7,
                     FlowerName = "Purple Lilium",
                     FlowerPrice = 12.99,
                     ImageURL = "https://cdn.shopify.com/s/files/1/0512/7477/6770/products/lilypurpleeyePURPLEDREAMCC_1024x1024.jpg?v=1616793109",
                     Info = "Purple Lilies represent pride, success, dignity, admiration & accomplishment. Purple stands for pride, success, admiration, dignity and accomplishment. Associated with royalty, purple lilies have always been regarded as being rare and exclusive. Because of this, purple lilies symbolise royalty, privilege and passion."
                 },
                 new Flower
                 {
                     Id = 8,
                     FlowerName = "Pink Orchid",
                     FlowerPrice = 13,
                     ImageURL = "https://img.freepik.com/free-photo/pink-phalaenopsis-orchid-flower_1373-561.jpg?w=2000",
                     Info = "As a symbol of grace, gentleness, innocence, happiness, playfulness, and fertility, pink orchids prove to be a sweet bloom. This pink flower is perfect to help growing families and expecting mothers celebrate their new bundle of joy."
                 },
                 new Flower
                 {
                     Id = 9,
                     FlowerName = "Pink Lotus",
                     FlowerPrice = 15.99,
                     ImageURL = "https://images.unsplash.com/photo-1616435577207-ca90abc6b732?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8bG90dXMlMjBmbG93ZXJ8ZW58MHx8MHx8&w=1000&q=80",
                     Info = "Pink lotus flowers are known as Buddha's earthly symbol, where a bud symbolizes one's spiritual journey and a fully-bloomed pink lotus represents enlightenment. Yellow lotus flowers symbolize openness and hospitality while red flowers have come to meant selfless love and compassion."
                 },
                 new Flower
                 {
                     Id = 10,
                     FlowerName = "Sunflower",
                     FlowerPrice = 2,
                     ImageURL = "https://cdn.apartmenttherapy.info/image/upload/f_jpg,q_auto:eco,c_fill,g_auto,w_1500,ar_1:1/stock%2FGettyImages-1312066960-cropped",
                     Info = "Sunflowers symbolize unwavering faith and unconditional love. It's perfect to send to your loved one if you want to express exactly how much you adore him or her. Sunflowers, especially the ones grown in farms, are often photographed stretching their tall stalks and vibrant petals towards the sun."
                 },
                 new Flower
                 {
                     Id = 11,
                     FlowerName = "Dried Lavander",
                     FlowerPrice = 3.55,
                     ImageURL = "https://m.media-amazon.com/images/W/WEBP_402378-T1/images/I/81ZVx7QvwwL._AC_SX679_.jpg",
                     Info = "Lavender flowers represent purity, silence, devotion, serenity, grace, and calmness. Purple is the color of royalty and speaks of elegance, refinement, and luxury, too. The color is also associated with the crown chakra, which is the energy center associated with higher purpose and spiritual connectivity. Dried lavander can be used to make tea or incents."
                 },
                 new Flower
                 {
                     Id = 12,
                     FlowerName = "Pink Zinnia",
                     FlowerPrice = 6.25,
                     ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6e/Zinnienbl%C3%BCte_Zinnia_elegans_stack15_20190722-RM-7222254.jpg/1280px-Zinnienbl%C3%BCte_Zinnia_elegans_stack15_20190722-RM-7222254.jpg",
                     Info = "Because of the wide variety of the Zinnia flower, not just in colors but also in the types, it symbolizes various values tied to friendship and strength. A pink zinnia flower represents paternal love, like we have for friends and family. It symbolizes life-long love and friendship – the kind that does not easily unravel."
                 },
                 new Flower
                 {
                     Id = 13,
                     FlowerName = "Daffodil",
                     FlowerPrice = 1.59,
                     ImageURL = "https://www.thespruce.com/thmb/G9evkIXztZcAoEcnpi-xIo0U4oU=/2656x2656/smart/filters:no_upscale()/planting-and-growing-daffodils-1402136_01-bb8eada2ffb4443dbb20a7b1f0f3dfce.jpg",
                     Info = "Daffodils are some of the first flowers we see in springtime and are a great indicator that winter is over. Because of this, they are seen to represent rebirth and new beginnings. Narcissi flowers are also seen to represent; creativity, inspiration, awareness and inner reflection, forgiveness, and vitality. If you give a bunch of narcissi to a loved one it means 'they're the only one' and is said to ensure happiness."
                 },
                 new Flower
                 {
                     Id = 14,
                     FlowerName = "Bluebell",
                     FlowerPrice = 1.55,
                     ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a8/Hyacinthoides_non-scripta_%28Common_Bluebell%29.jpg/1200px-Hyacinthoides_non-scripta_%28Common_Bluebell%29.jpg",
                     Info = "If you wear a garland of bluebells, you will be compelled to tell the truth When a bluebells bell rings, it calls all the fairies to a gathering, but if a human hears the bell, they will be visited by a malicious fairy and die soon after. Bluebell woods are enchanted. Fairies used them to lure and trap people in their nether world. If you turn one of the flowers inside out without tearing it, you will eventually win the one you love. In the language of flowers, the bluebell symbolises constancy, humility and gratitude."
                 },
                 new Flower
                 {
                     Id = 15,
                     FlowerName = "Pink Peony",
                     FlowerPrice = 6.98,
                     ImageURL = "https://mitchellsnursery.com/wp-content/uploads/2022/01/image.jpeg",
                     Info = "Peony flowers symbolise many different things around the world! Because of the Greek myth with Paeonia the nymph, peonies grew to symbolise bashfulness. This then evolved into the Victorians believing that if you dug up a peony, fairies would come and put a curse on you. We adore pink peonies and they're super popular for wedding bouquets as they symbolise good luck and prosperity."
                 },
                 new Flower
                 {
                     Id = 16,
                     FlowerName = "Purple Aster",
                     FlowerPrice = 3.99,
                     ImageURL = "https://www.lovingly.com/wp-content/uploads/2021/07/AdobeStock_222030786-683x1024.jpeg",
                     Info = "Asters are named for their star-shaped flowers. It comes from the Greek astḗr, meaning “star.” Other star-related words are based on the same root, such as astronomy, asteroid, and asterisk. Purple asters symbolize wisdom and royalty and are the most popular color. White asters symbolize purity and innocence. Red asters symbolize undying devotion. Pink asters symbolize sensitivity and love."
                 },
                 new Flower
                 {
                     Id = 17,
                     FlowerName = "Orange Calendula",
                     FlowerPrice = 4.75,
                     ImageURL = "https://upload.wikimedia.org/wikipedia/commons/a/a7/Pot_marigold.jpg",
                     Info = "Calendula has been a symbol of sunshine and fire for many centuries. The colors of the calendula flower are yellow or orange, which represent the path of the sun throughout an autumn day. It is thought that the flower holds all of the sunlight of autumn. Those with an autumn birthday are said to be warm, friendly and easy going."
                 },
                 new Flower
                 {
                    Id = 18,
                    FlowerName = "Pink Carnation",
                    FlowerPrice = 5.99,
                    ImageURL = "https://images.immediate.co.uk/production/volatile/sites/18/2021/07/JI_190620_PerpetualCarnations_003-30143f4.jpg",
                    Info = "The pink carnation is often given as a symbol of heartfelt gratitude to say, “Thank you” and also “I will never forget you”. Light pink carnations are often a favourite choice when it comes to a Mother's Day bouquet as it symbolises mother-like love that is soft and tender."
                 });


            base.OnModelCreating(builder);
        }

    }
}