namespace FlowerShop.Services.Carts
{
    using FlowerShop.ViewModels;

    public class CartQueryServiceModel
    {
        public IEnumerable<CartDto> Flowers { get; set; }
        public IEnumerable<AddressDto> Addresses { get; set; }
    }
}
