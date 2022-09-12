using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerShop.Data.Migrations
{
    public partial class FlowerInfoColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Flowers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Info",
                value: "Pink dahlias symbolize kindness and beauty. These flowers also symbolize feminine beauty, which makes them a great gift for any special lady in your life. And they're perfect for Mothers' Day! Dahlias are the official birth flower for August, although other traditions recognize them as the November birth month flower instead.Dahlia flowers hold different symbolism depending on their colors.Generally,these summer - blooming and vivid flowers symbolize elegance,inner strength,change,creativity,and dignity.Though most of the symbolism is positive,dahlias still carry a few negative connotations,including betrayal,dishonesty,and instability. ");

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Info",
                value: "The hyacinth is the flower of the sun god Apollo and is a symbol of peace, commitment and beauty, but also of power and pride. The hyacinth is often found in Christian churches as a symbol of happiness and love. If someone gives you a Purple Hyacinth they want to show sorrow and they ask for forgiveness");

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Info",
                value: "A light rosy tone is often associated with femininity, so, naturally, the pink rose meaning is that of grace and sweetness. Other interpretations include gentleness, appreciation, joy, thankfulness, and elegance. The variety of meanings make giving pink roses appropriate for so many occasions.");

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Info",
                value: "There isn't a great meaning behind this flower. It is simply beautiful and prized for it's uniqueness");

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Info",
                value: "The alstroemeria flower has an array of meanings depending on the colour. But the beautiful blooms always connect to a similar meaning of friendship, love, strength and devotion. This alstroemeria colour represents passion. It's a fun way to say 'I love you' without red roses!");

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 6,
                column: "Info",
                value: "The gerbera has different meanings to different cultures. The Egyptians believed that they symbolised a closeness to nature and a devotion to the sun, whereas the Celts thought they lessened the sorrows and stresses of everyday life. Generally, gerberas symbolise innocence, purity, cheerfulness and loyal love. Orange gerberas represent happiness, joy, friendship, and warmth, which make these alluring blooms the perfect gifting flower for your friends and colleagues.");

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 7,
                column: "Info",
                value: "Purple Lilies represent pride, success, dignity, admiration & accomplishment. Purple stands for pride, success, admiration, dignity and accomplishment. Associated with royalty, purple lilies have always been regarded as being rare and exclusive. Because of this, purple lilies symbolise royalty, privilege and passion.");

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 8,
                column: "Info",
                value: "As a symbol of grace, gentleness, innocence, happiness, playfulness, and fertility, pink orchids prove to be a sweet bloom. This pink flower is perfect to help growing families and expecting mothers celebrate their new bundle of joy.");

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 9,
                column: "Info",
                value: "Pink lotus flowers are known as Buddha's earthly symbol, where a bud symbolizes one's spiritual journey and a fully-bloomed pink lotus represents enlightenment. Yellow lotus flowers symbolize openness and hospitality while red flowers have come to meant selfless love and compassion.");

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 10,
                column: "Info",
                value: "Sunflowers symbolize unwavering faith and unconditional love. It's perfect to send to your loved one if you want to express exactly how much you adore him or her. Sunflowers, especially the ones grown in farms, are often photographed stretching their tall stalks and vibrant petals towards the sun.");

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 11,
                column: "Info",
                value: "Lavender flowers represent purity, silence, devotion, serenity, grace, and calmness. Purple is the color of royalty and speaks of elegance, refinement, and luxury, too. The color is also associated with the crown chakra, which is the energy center associated with higher purpose and spiritual connectivity. Dried lavander can be used to make tea or incents.");

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 12,
                column: "Info",
                value: "Because of the wide variety of the Zinnia flower, not just in colors but also in the types, it symbolizes various values tied to friendship and strength. A pink zinnia flower represents paternal love, like we have for friends and family. It symbolizes life-long love and friendship – the kind that does not easily unravel.");

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 13,
                column: "Info",
                value: "Daffodils are some of the first flowers we see in springtime and are a great indicator that winter is over. Because of this, they are seen to represent rebirth and new beginnings. Narcissi flowers are also seen to represent; creativity, inspiration, awareness and inner reflection, forgiveness, and vitality. If you give a bunch of narcissi to a loved one it means 'they're the only one' and is said to ensure happiness.");

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 14,
                column: "Info",
                value: "If you wear a garland of bluebells, you will be compelled to tell the truth When a bluebells bell rings, it calls all the fairies to a gathering, but if a human hears the bell, they will be visited by a malicious fairy and die soon after. Bluebell woods are enchanted. Fairies used them to lure and trap people in their nether world. If you turn one of the flowers inside out without tearing it, you will eventually win the one you love. In the language of flowers, the bluebell symbolises constancy, humility and gratitude.");

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 15,
                column: "Info",
                value: "Peony flowers symbolise many different things around the world! Because of the Greek myth with Paeonia the nymph, peonies grew to symbolise bashfulness. This then evolved into the Victorians believing that if you dug up a peony, fairies would come and put a curse on you. We adore pink peonies and they're super popular for wedding bouquets as they symbolise good luck and prosperity.");

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 16,
                column: "Info",
                value: "Asters are named for their star-shaped flowers. It comes from the Greek astḗr, meaning “star.” Other star-related words are based on the same root, such as astronomy, asteroid, and asterisk. Purple asters symbolize wisdom and royalty and are the most popular color. White asters symbolize purity and innocence. Red asters symbolize undying devotion. Pink asters symbolize sensitivity and love.");

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 17,
                column: "Info",
                value: "Calendula has been a symbol of sunshine and fire for many centuries. The colors of the calendula flower are yellow or orange, which represent the path of the sun throughout an autumn day. It is thought that the flower holds all of the sunlight of autumn. Those with an autumn birthday are said to be warm, friendly and easy going.");

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 18,
                column: "Info",
                value: "The pink carnation is often given as a symbol of heartfelt gratitude to say, “Thank you” and also “I will never forget you”. Light pink carnations are often a favourite choice when it comes to a Mother's Day bouquet as it symbolises mother-like love that is soft and tender.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Info",
                table: "Flowers");
        }
    }
}
