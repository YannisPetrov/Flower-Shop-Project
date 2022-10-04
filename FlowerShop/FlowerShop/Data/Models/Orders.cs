namespace FlowerShop.Data.Models
{
    public class Orders
    {
        public int OrderId { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
        public string Flowers { get; set; }
        public double TotalPrice { get; set; }
        /*public double Quantity { get; set; }*/

    }
}
