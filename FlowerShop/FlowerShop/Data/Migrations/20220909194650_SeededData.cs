using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerShop.Data.Migrations
{
    public partial class SeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Flowers",
                columns: new[] { "Id", "FlowerName", "FlowerPrice", "ImageURL" },
                values: new object[,]
                {
                    { 1, "Pink Dahlia", 5.9900000000000002, "https://keyassets.timeincuk.net/inspirewp/live/wp-content/uploads/sites/8/2020/10/GettyImages-1167560383_413205512_747927761.jpg" },
                    { 2, "Purple Hyacinthus", 2.3900000000000001, "https://upload.wikimedia.org/wikipedia/commons/7/7e/Hyacinth_-_Anglesey_Abbey.jpg" },
                    { 3, "Pink Rose", 5.6900000000000004, "https://upload.wikimedia.org/wikipedia/commons/7/77/Pink_rose_.JPG" },
                    { 4, "Fire Tulip", 4.5499999999999998, "https://cdn.britannica.com/37/227037-050-CA792866/Broken-tulip-flower.jpg" },
                    { 5, "Red Alstromeria", 2.3300000000000001, "https://cdn.shopify.com/s/files/1/1116/9522/products/BLALSTRD50_A_1024x1024.jpg?v=1569156223" },
                    { 6, "Orange Gerbera", 2.5899999999999999, "https://www.gardeningknowhow.com/wp-content/uploads/2012/03/gerbera.jpg" },
                    { 7, "Purple Lilium", 12.99, "https://cdn.shopify.com/s/files/1/0512/7477/6770/products/lilypurpleeyePURPLEDREAMCC_1024x1024.jpg?v=1616793109" },
                    { 8, "Pink Orchid", 13.0, "https://img.freepik.com/free-photo/pink-phalaenopsis-orchid-flower_1373-561.jpg?w=2000" },
                    { 9, "Pink Lotus", 15.99, "https://images.unsplash.com/photo-1616435577207-ca90abc6b732?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8bG90dXMlMjBmbG93ZXJ8ZW58MHx8MHx8&w=1000&q=80" },
                    { 10, "Sunflower", 2.0, "https://cdn.apartmenttherapy.info/image/upload/f_jpg,q_auto:eco,c_fill,g_auto,w_1500,ar_1:1/stock%2FGettyImages-1312066960-cropped" },
                    { 11, "Dried Lavander", 3.5499999999999998, "https://m.media-amazon.com/images/W/WEBP_402378-T1/images/I/81ZVx7QvwwL._AC_SX679_.jpg" },
                    { 12, "Pink Zinnia", 6.25, "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6e/Zinnienbl%C3%BCte_Zinnia_elegans_stack15_20190722-RM-7222254.jpg/1280px-Zinnienbl%C3%BCte_Zinnia_elegans_stack15_20190722-RM-7222254.jpg" },
                    { 13, "Daffodil", 1.5900000000000001, "https://www.thespruce.com/thmb/G9evkIXztZcAoEcnpi-xIo0U4oU=/2656x2656/smart/filters:no_upscale()/planting-and-growing-daffodils-1402136_01-bb8eada2ffb4443dbb20a7b1f0f3dfce.jpg" },
                    { 14, "Bluebell", 1.55, "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a8/Hyacinthoides_non-scripta_%28Common_Bluebell%29.jpg/1200px-Hyacinthoides_non-scripta_%28Common_Bluebell%29.jpg" },
                    { 15, "Pink Peony", 6.9800000000000004, "https://mitchellsnursery.com/wp-content/uploads/2022/01/image.jpeg" },
                    { 16, "Purple Aster", 3.9900000000000002, "https://www.lovingly.com/wp-content/uploads/2021/07/AdobeStock_222030786-683x1024.jpeg" },
                    { 17, "Orange Calendula", 4.75, "https://upload.wikimedia.org/wikipedia/commons/a/a7/Pot_marigold.jpg" },
                    { 18, "Pink Carnation", 5.9900000000000002, "https://images.immediate.co.uk/production/volatile/sites/18/2021/07/JI_190620_PerpetualCarnations_003-30143f4.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 18);
        }
    }
}
