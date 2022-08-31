namespace FlowerShop.Data.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        
        public int FlowerId { get; set; }

        public Flower Flower { get; set; }

        public string FlowerName { get; set; }
        public double FlowerPrice { get; set; }
        public string ImageURL { get; set; }

    }
}
