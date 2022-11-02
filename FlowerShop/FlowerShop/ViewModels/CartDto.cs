namespace FlowerShop.ViewModels
{
    using FlowerShop.Data.Models;

    public class CartDto
    {
        public int CartId { get; set; }
        public string UserId { get; set; }
        public int FlowerId { get; set; }
        public string FlowerName { get; init; }
        public double FlowerPrice { get; init; }
        public string ImageURL { get; init; }
        public ICollection<AddressDto> Addresses { get; init; }

        public Cart ToModel()
        {
            Cart result = new Cart();
            result.CartId = CartId;
            result.UserId = UserId;
            result.FlowerId = FlowerId;
            result.FlowerName = FlowerName;
            result.FlowerPrice = FlowerPrice;
            result.ImageURL = ImageURL;

            return result;
        }
    }
}
