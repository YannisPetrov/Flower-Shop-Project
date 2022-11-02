namespace FlowerShop.Services.Orders
{
    using FlowerShop.ViewModels;

    public class OrderQueryServiceModel
    {
        public IEnumerable<OrderDto> Orders { get; set; }
    }
}
