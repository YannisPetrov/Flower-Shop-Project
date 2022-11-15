namespace FlowerShop.Services.ServiceModels.OrdersServiceModels
{
    using FlowerShop.ViewModels;

    public class OrderQueryServiceModel
    {
        public IEnumerable<OrderDto> Orders { get; set; }
    }
}
