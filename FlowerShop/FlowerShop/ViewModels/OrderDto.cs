namespace FlowerShop.ViewModels
{
    using FlowerShop.Data.Models;

    public class OrderDto
    {
        public int OrderId { get; set; }

        public string UserId { get; set; }
        public string Flowers { get; set; }
        public double TotalPrice { get; set; }

        public string OrderAddress { get; set; }

        public Orders ToModel()
        {
            Orders result = new Orders();
            result.OrderId = OrderId;
            result.UserId = UserId;
            result.Flowers = Flowers;
            result.TotalPrice = TotalPrice;
            result.AddressIdByInfo = OrderAddress;
            return result;
        }
    }
}
