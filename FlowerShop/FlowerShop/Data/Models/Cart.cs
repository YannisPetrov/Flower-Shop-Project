namespace FlowerShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Cart
    {
        public int CartId { get; set; }

        [Required]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int FlowerId { get; set; }

        public Flower Flower { get; set; }

        [Required]
        [MinLength(3)]
        public string FlowerName { get; set; }

        [Required]
        public double FlowerPrice { get; set; }

        [Required]
        [Url]
        public string ImageURL { get; set; }

    }
}
