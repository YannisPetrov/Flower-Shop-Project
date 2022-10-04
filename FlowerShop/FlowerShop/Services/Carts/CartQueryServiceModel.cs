namespace FlowerShop.Services.Carts
{
    using FlowerShop.Services.Addresses;
    public class CartQueryServiceModel
    {
        public IEnumerable<CartModel> Flowers { get; set; }
        public IEnumerable<AddressModel> Addresses { get; set; }
    }
}
