namespace FlowerShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Flower
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string FlowerName { get; set; }

        [Required]
        public double FlowerPrice { get; set; }
        
        [Required]
        [Url]
        public string ImageURL { get; set; }

        [Required]
        [MinLength(155)]
        public string Info { get; set; }

        public ICollection<Cart> Cart { get; set; }

    }
}
