namespace FlowerShop.Services.Orders
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public string Flowers { get; set; }
        public double TotalPrice { get; set; }
        /*public double Quantity { get; set; }*/
    }
}
