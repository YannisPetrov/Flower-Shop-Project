 namespace FlowerShop.Services.Flowers
{
    using FlowerShop.Models;
    public interface IFlowerService
    {
        FlowerQueryServiceModel All(string searchTerm, int currentPage, int flowersPerPage);
    }
}
