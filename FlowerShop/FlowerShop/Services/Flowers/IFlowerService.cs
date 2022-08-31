 namespace FlowerShop.Services.Flowers
{
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
        int Order(string userId,
                  string flowersInCart,
                  double totalPrice);

        int Create(string flowerName,
                   double flowerPrice,
                   string imageURL);

        bool Edit(int id,
                 string flowerName,
                 double flowerPrice,
                 string imageURL);

        bool Delete(int id);
        bool DeleteFromCart(string userId, int flowerInCartId);

    }
}
