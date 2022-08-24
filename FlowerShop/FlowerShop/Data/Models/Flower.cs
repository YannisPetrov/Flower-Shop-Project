namespace FlowerShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Flower
    {
        public int Id { get; set; }

        [Required]
        public string FlowerName { get; set; }

        [Required]
        public double FlowerPrice { get; set; }
        
        [Required]
        public string ImageURL { get; set; }

        public ICollection<Cart> Cart { get; set; }

    }
}
