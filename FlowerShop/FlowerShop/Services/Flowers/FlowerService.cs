namespace FlowerShop.Services.Flowers
{
    using System.Linq;
    using FlowerShop.Data;
    public class FlowerService : IFlowerService
    {
        private readonly FlowerShopDbContext data;

        public FlowerService(FlowerShopDbContext data) 
            => this.data = data;
        

        public FlowerQueryServiceModel All(
            string searchTerm,
            int currentPage,
            int flowersPerPage)
        {
            var flowersQuery = this.data.Flowers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                flowersQuery = flowersQuery.Where(f =>
                f.FlowerName.ToLower().Contains(searchTerm.ToLower()));
            }

            var totalFlowers = flowersQuery.Count();

            var flowers = flowersQuery
                .Skip((currentPage - 1) * flowersPerPage)
                .Take(flowersPerPage)
                .Select(f => new FlowerServiceModel
                {
                    Id = f.Id,
                    FlowerName = f.FlowerName,
                    FlowerPrice = f.FlowerPrice,
                    ImageURL = f.ImageURL
                })
                .ToList();

            return new FlowerQueryServiceModel
            {
                TotalFlowers = totalFlowers,
                CurrentPage = currentPage,
                FlowersPerPage = flowersPerPage,
                Flowers = flowers
            };
        }
 
    }
}
