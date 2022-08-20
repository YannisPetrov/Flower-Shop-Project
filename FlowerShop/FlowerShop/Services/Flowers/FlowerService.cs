namespace FlowerShop.Services.Flowers
{
    using System.Collections.Generic;
    using System.Linq;
    using FlowerShop.Data;
    using FlowerShop.Data.Models;
    using FlowerShop.Models;
    using FlowerShop.Services;

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

            var flowers = GetFlowers(flowersQuery
                .Skip((currentPage - 1) * flowersPerPage)
                .Take(flowersPerPage));

            return new FlowerQueryServiceModel
            {
                TotalFlowers = totalFlowers,
                CurrentPage = currentPage,
                FlowersPerPage = flowersPerPage,
                Flowers = flowers
            };
        }

        public FlowerServiceModel Details(int id)
        => this.data
            .Flowers
            .Where(f => f.Id == id)
            .Select(f => new FlowerServiceModel
            {
                Id = f.Id,
                FlowerName = f.FlowerName,
                FlowerPrice = f.FlowerPrice,
                ImageURL = f.ImageURL
            })
            .FirstOrDefault();

        public int Create(string flowerName, double flowerPrice, string imageURL)
        {
            var flowerData = new Flower
            {
                FlowerName = flowerName,
                FlowerPrice = flowerPrice,
                ImageURL = imageURL
            };

            this.data.Flowers.Add(flowerData);

            this.data.SaveChanges();

            return flowerData.Id;
        }

        public bool Edit(int id, string flowerName, double flowerPrice, string imageURL)
        {
            var flowerData = this.data.Flowers.Find(id);

            if(flowerData == null)
            {
                return false;
            }

                flowerData.FlowerName = flowerName;
                flowerData.FlowerPrice = flowerPrice;
                flowerData.ImageURL = imageURL;
             

            this.data.SaveChanges();

            return true;
        }

        /*       public IEnumerable<FlowerServiceModel> ByUser(string userId)
                => this.GetFlowers(this.data.Flowers
                    .Where(f => f.FlowerName == userId));*/


        private static IEnumerable<FlowerServiceModel> GetFlowers(IQueryable<Flower> flowerQuery)
            => flowerQuery.Select(f => new FlowerServiceModel
            {
                Id = f.Id,
                FlowerName = f.FlowerName,
                FlowerPrice = f.FlowerPrice,
                ImageURL = f.ImageURL
            })
            .ToList();

        
    }
}
