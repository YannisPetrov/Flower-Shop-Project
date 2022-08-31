namespace FlowerShop.Services.Flowers
{
    using System.Collections.Generic;
    using System.Linq;
    using FlowerShop.Data;
    using FlowerShop.Data.Models;

    public class FlowerService : IFlowerService
    {
        private readonly FlowerShopDbContext data;


        public FlowerService(FlowerShopDbContext data)
        =>   this.data = data;

        public FlowerQueryServiceModel All(
            string searchTerm,
            int currentPage,
            int flowersPerPage){

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


        public int AddToCart(string userId,
                             int flowerId,
                             string flowerName,
                             double flowerPrice,
                             string imageUrl)
        {
            var cartData = new Cart
            {
                UserId = userId,
                FlowerId = flowerId,
                FlowerName = flowerName,
                FlowerPrice = flowerPrice,
                ImageURL = imageUrl
            };

            this.data.Carts.Add(cartData);

            this.data.SaveChanges();

            return cartData.FlowerId;
        }

        public int Order(string userId,
                         string flowersInCart,
                         double totalPrice)
        {
            var ivan = this.data
                            .Carts
                            .AsQueryable()
                            .Where(f => f.UserId == userId)
                            .Select(b => new Orders
                            {
                                UserId = b.UserId,
                                Flowers = b.FlowerName,
                                TotalPrice = b.FlowerPrice
                            });


            var orderData = new Orders
                {
                    UserId = userId,
                    Flowers = flowersInCart,
                    TotalPrice = totalPrice
                };

/*            this.data.Database.ExecuteSqlCommand("insert into student(studentname) 
            values('New Student')");*/

            this.data.SaveChanges();

            return orderData.OrderId;
        }


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

        public bool Delete(int id)
        {
            var flowerData = this.data.Flowers.Find(id);

            if (flowerData == null)
            {
                return false;
            }

            this.data.Flowers.Remove(flowerData);

            this.data.SaveChanges();

            return true;
        }

        public bool DeleteFromCart(int flowerInCartId)
        {
            var cartData = this.data.Carts.Find(flowerInCartId);

            if (cartData == null)
            {
                return false;
            }

            this.data.Carts.Remove(cartData);

            this.data.SaveChanges();

            return true;
        }

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
