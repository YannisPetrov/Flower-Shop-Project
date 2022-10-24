namespace FlowerShop.Services.Flowers
    public interface IFlowerService
    {
        FlowerQueryServiceModel All(
            string searchTerm,
            int currentPage, 
            int flowersPerPage);

        FlowerServiceModel Details(int id);

        int AddToCart(string userId,
                      int flowerId,
                      string flowerName,
                      double flowerPrice,
                      string imageUrl);
        int AddAddress(string userId,
                       string fullName,
                       string addressInfo,
                       string populatedPlace,
                       string phoneNumber);
        int Order(string userId,
                  string flowers,
                  double totalPrice,
                  string addressId/*,
                  int quantity*/);

        int Create(string flowerName,
                   double flowerPrice,
                   string imageURL,
                   string info);

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