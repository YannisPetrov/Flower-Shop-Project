namespace FlowerShop.Services.Flowers
{
    using FlowerShop.Data.Models;
    using FlowerShop.Services.Carts;
    using FlowerShop.Services.Orders;

    public interface IFlowerService
    {
        FlowerQueryServiceModel All(
            string searchTerm,
            int currentPage, 
            int flowersPerPage);

        FlowerServiceModel Details(int id);

        OrderQueryServiceModel AllOrders();

        OrderQueryServiceModel MyOrders(string id);

        CartQueryServiceModel MyCart(string id);

        int AddToCart(Cart cart);
        int AddAddress(Address address);
        int Order(string userId,
                  string flowers,
                  double totalPrice,
                  string addressId/*,
                  int quantity*/);

        int Create(Flower flower);

        bool Edit(int id,
                  string flowerName,
                  double flowerPrice,
                  string imageURL,
                  string info);

        bool Delete(int id);
        bool DeleteFromCart(string userId,
                            int flowerInCartId);

    }
}