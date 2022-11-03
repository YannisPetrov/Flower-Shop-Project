namespace FlowerShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Orders
    {
        public int OrderId { get; set; }

        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
        [Required]
        [MinLength(3)]
        public string Flowers { get; set; }

        [Required]
        public double TotalPrice { get; set; }

        [Required]
        public string AddressIdByInfo { get; set; }
        /*public double Quantity { get; set; }*/

    }
}
