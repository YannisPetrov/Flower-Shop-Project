namespace FlowerShop.Services.Flowers
{
    using System.Collections.Generic;
    using System.Linq;
    using FlowerShop.Data;
    using FlowerShop.Data.Models;
    using FlowerShop.Services.Carts;
    using FlowerShop.Services.Orders;
    using FlowerShop.ViewModels;

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
                f.FlowerName.ToLower()
                .Contains(searchTerm.ToLower()));
            }

            var totalFlowers = flowersQuery.Count();

            var flowers =
                 GetFlowers(flowersQuery
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
                ImageURL = f.ImageURL,
                Info = f.Info
            })
            .FirstOrDefault();

        public OrderQueryServiceModel AllOrders()
        {
            var orders = this.data
               .Orders
                .Select(f => new OrderDto
                {
                    Flowers = f.Flowers,
                    TotalPrice = f.TotalPrice,
                    OrderAddress = f.AddressIdByInfo

                })
                .ToList();

            return new OrderQueryServiceModel
            {
                Orders = orders
            };
        }

        public OrderQueryServiceModel MyOrders(string id)
        {
            var orders = this.data.Orders
                .Where(c => c.UserId == id)
                .Select(f => new OrderDto
                {
                    OrderId = f.OrderId,
                    Flowers = f.Flowers,
                    TotalPrice = f.TotalPrice

                })
                .ToList();

            return new OrderQueryServiceModel
            {
                Orders = orders
            };
        }

        public CartQueryServiceModel MyCart(string id)
        {
            var userAddress = this.data.Addresses
                .Where(a => a.UserId == id)
                .Select(a => new AddressDto
                {
                    FullName = a.FullName,
                    AddressInfo = a.AddressInfo,
                    PopulatedPlace = a.PopulatedPlace,
                    PhoneNumber = a.PhoneNumber
                })
                .ToList();

            var flowersByCart = this.data.Carts
                .Where(c => c.UserId == id)
                .Select(f => new CartDto
                {
                    FlowerId = f.FlowerId,
                    FlowerName = f.FlowerName,
                    FlowerPrice = f.FlowerPrice,
                    ImageURL = f.ImageURL,
                    Addresses = userAddress
                })
                .ToList();

            return new CartQueryServiceModel
            {
                Addresses = userAddress,
                Flowers = flowersByCart
            };
        }

        public int AddToCart(Cart cart)
        {
            this.data.Carts.Add(cart);

            this.data.SaveChanges();

            return cart.FlowerId;
        }

        public int AddAddress(Address address)
        {
            this.data.Addresses.Add(address);

            this.data.SaveChanges();

            return address.AddressId;
        }

        public int Order(string userId,
                         string flowers,
                         double totalPrice,
                         string addressId/*,
                         double quantity*/) 
        {
            var cartData = this.data
                .Carts
                .Where(c => c.UserId == userId)
                .FirstOrDefault();

            var orderData = new Orders
                {
                    UserId = userId,
                    Flowers = flowers,
                    TotalPrice = totalPrice,
                    AddressIdByInfo = addressId
                    /*Quantity = quantity*/
                };

            this.data.Orders.Add(orderData);

            this.data.Carts.Remove(cartData);

            this.data.SaveChanges();

            return orderData.OrderId;
        }


        public int Create(Flower flower)
        {
            this.data.Flowers.Add(flower);

            this.data.SaveChanges();

            return flower.Id;
        }

        public bool Edit(int id,
                         string flowerName,
                         double flowerPrice,
                         string imageURL,
                         string info)
        {
            var flowerData = this.data.Flowers.Find(id);

            if(flowerData == null)
            {
                return false;
            }

                flowerData.FlowerName = flowerName;
                flowerData.FlowerPrice = flowerPrice;
                flowerData.ImageURL = imageURL;
                flowerData.Info = info;
             

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

        public bool DeleteFromCart(string userId, int flowerInCartId)
        {
            var cartData = this.data
                .Carts
                .Where(c => c.UserId == userId)
                .Where(c => c.FlowerId == flowerInCartId)
                .FirstOrDefault();

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
