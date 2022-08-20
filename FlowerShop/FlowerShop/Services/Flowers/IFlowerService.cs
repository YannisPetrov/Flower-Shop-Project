 namespace FlowerShop.Services.Flowers
{
    using FlowerShop.Models;
    using FlowerShop.Services;
    public interface IFlowerService
    {
        FlowerQueryServiceModel All(
            string searchTerm,
            int currentPage, 
            int flowersPerPage);

        FlowerServiceModel Details(int id);

        int Create(string flowerName,
                   double flowerPrice,
                   string imageURL);

        bool Edit(int id,
                 string flowerName,
                 double flowerPrice,
                 string imageURL);

        /*        IEnumerable<FlowerServiceModel> ByUser(string userId);*/

    }
}
