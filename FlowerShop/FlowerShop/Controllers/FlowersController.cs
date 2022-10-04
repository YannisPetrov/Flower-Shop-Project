﻿namespace FlowerShop.Controllers
{
    using FlowerShop.Models.Flowers;
    using FlowerShop.Data;
    using FlowerShop.Infrastructure.Extensions;
    using FlowerShop.Services.Flowers;
    using FlowerShop.Services.Carts;
    using FlowerShop.Services.Orders;
    using FlowerShop.Services.Addresses;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using FlowerShop.Models.Addressess;

    public class FlowersController : Controller
    {
        private readonly IFlowerService flowers;
        private readonly FlowerShopDbContext data;

        //Initializing the constructor
        public FlowersController(IFlowerService flowers, FlowerShopDbContext data)
        {
            this.flowers = flowers;
            this.data = data;
        }

        [HttpGet]
        public IActionResult All([FromQuery]AllFlowersQueryModel query)
        {

            var queryResult = this.flowers.All(
                query.SearchTerm,
                query.CurrentPage,
                AllFlowersQueryModel.FlowersPerPage);

            query.TotalFlowers = queryResult.TotalFlowers;
            query.Flowers = queryResult.Flowers;


            return View(query);
        }

        public IActionResult Details(int id)
        {
            var flower = this.flowers.Details(id);

            return View(flower);
        }

        [Authorize]
        public IActionResult Add() => View();
        
        [HttpPost]
        public IActionResult Add(FlowerFormModel flower)
        {
            if (!ModelState.IsValid)
            {
                return View(flower);
            }

            this.flowers.Create(flower.FlowerName,
                                flower.FlowerPrice,
                                flower.ImageURL,
                                flower.Info);

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult AddAddress() => View();

        [HttpPost]
        public IActionResult AddAddress(AddressFormModel address)
        {

            this.flowers.AddAddress(address.UserId,
                                    address.FullName,
                                    address.AddressInfo,
                                    address.PopulatedPlace,
                                    address.PhoneNumber);
                                    


            return RedirectToAction(nameof(MyCart));
        }

        [Authorize]
        public IActionResult MyCart([FromQuery] CartQueryServiceModel query)
           {


            var userId = this.User.Id();

            var userAddress = this.data.Addresses
                .Where(a => a.UserId == userId)
                .Select(a => new AddressModel
                {
                    FullName = a.FullName,
                    AddressInfo = a.AddressInfo,
                    PopulatedPlace = a.PopulatedPlace,
                    PhoneNumber = a.PhoneNumber
                })
                .ToList();

            var flowersByCart = this.data.Carts
                .Where(c => c.UserId == userId)
                .Select(f => new CartModel
                {
                    FlowerId = f.FlowerId,
                    FlowerName = f.FlowerName,
                    FlowerPrice = f.FlowerPrice,
                    ImageURL = f.ImageURL,
                    Addresses = userAddress
                })
                .ToList();

            query.Flowers = flowersByCart;
            query.Addresses = userAddress;
            

            return View(query);

           }


        [HttpPost]
        public IActionResult AddToCart(string userId,
                                       int flowerId,
                                       string flowerName,
                                       double flowerPrice,
                                       string imageUrl)
        {

            this.flowers.AddToCart(userId, 
                                   flowerId, 
                                   flowerName, 
                                   flowerPrice, 
                                   imageUrl);

            return RedirectToAction(nameof(MyCart));
        }

        public IActionResult Order(string userId,
                                   string flowers, 
                                   double totalPrice/*,
                                   double quantity*/)
        {

            this.flowers.Order(userId,
                               flowers, 
                               totalPrice/*, 
                               quantity*/);

            return RedirectToAction(nameof(MyOrders));
        }


        public IActionResult Edit(int id)
        {
            var flower = this.flowers.Details(id);

            return View(new FlowerFormModel
            {
                FlowerName = flower.FlowerName,
                FlowerPrice = flower.FlowerPrice,
                ImageURL = flower.ImageURL,
                Info = flower.Info
            });
        }

        [HttpPost]
        public IActionResult Edit(int id, FlowerFormModel flower)
        {
            if (!ModelState.IsValid)
            {
                return View(flower);
            }

            this.flowers.Edit(id,
                              flower.FlowerName,
                              flower.FlowerPrice,
                              flower.ImageURL,
                              flower.Info);



            return RedirectToAction(nameof(All));

        }
        public IActionResult Delete(int id)
        {
            this.flowers.Delete(id);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public IActionResult DeleteFromCart(string userId,
                                            int flowerInCartId)
        {
            this.flowers.DeleteFromCart(userId, flowerInCartId);

            return RedirectToAction(nameof(MyCart));
        }

        [Authorize]
        public IActionResult MyOrders()
        {
            var userId = this.User.Id();

            var orders = this.data.Orders
                .Where(c => c.UserId == userId)
                .Select(f => new OrderModel
                {
                    Flowers = f.Flowers,
                    TotalPrice = f.TotalPrice

                })
                .ToList();

            return View(orders);
        }

        [Authorize]
        public IActionResult AllOrders()
        {

            var orders = this.data.Orders
                .Select(f => new OrderModel
                {
                    Flowers = f.Flowers,
                    TotalPrice = f.TotalPrice

                })
                .ToList();

            return View(orders);
        }
    }
}
