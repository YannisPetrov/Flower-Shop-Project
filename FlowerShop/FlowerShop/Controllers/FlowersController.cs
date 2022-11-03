namespace FlowerShop.Controllers
{
    using FlowerShop.Models.Flowers;
    using FlowerShop.Data;
    using FlowerShop.Infrastructure.Extensions;
    using FlowerShop.Services.Flowers;
    using FlowerShop.Services.Carts;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using FlowerShop.ViewModels;

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
        [HttpGet]
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
        public IActionResult AddAddress(AddressFormDto address)
        {
            this.flowers.AddAddress(address.ToModel());
                                    
            return RedirectToAction(nameof(MyCart));
        }

        [Authorize]
        public IActionResult MyCart([FromQuery] CartQueryServiceModel query)
           {

            var userId = this.User.Id();

            var myCart = this.flowers.MyCart(userId);

            query.Flowers = myCart.Flowers;
            query.Addresses = myCart.Addresses;
            

            return View(query);
           }


        [HttpPost]
        public IActionResult AddToCart(AddToCartDto addToCart)
        {

            this.flowers.AddToCart(addToCart.ToModel());

            return RedirectToAction(nameof(MyCart));
        }

        public IActionResult Order(string userId,
                                           string flowers,
                                           double totalPrice,
                                           string addressId/*,
                                   double quantity*/)
        {

            this.flowers.Order(userId,
                               flowers,
                               totalPrice,
                               addressId/*, 
                               quantity*/);

            return RedirectToAction(nameof(MyOrders));
        }

        [Authorize]
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

        [HttpPost]
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

            var orders = this.flowers.MyOrders(userId);

            return View(orders);
        }

        [Authorize]
        public IActionResult AllOrders()
        {

            var orders = this.flowers.AllOrders();

            return View(orders);
        }
    }
}
