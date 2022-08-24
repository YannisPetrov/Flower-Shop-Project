namespace FlowerShop.Controllers
{

    using FlowerShop.Models.Flowers;
    using FlowerShop.Data;
    using FlowerShop.Data.Models;
    using FlowerShop.Services.Flowers;
    using FlowerShop.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using FlowerShop.Services.Carts;

    public class FlowersController : Controller
    {
        private readonly IFlowerService flowers;
        private readonly FlowerShopDbContext data;


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


           public IActionResult MyCart()
           {

            var userId = this.User.Id();

            var flowersByCart = this.data.Carts
                .Where(c => c.UserId == userId)
                .Select(f => new CartModel
                {
                    FlowerId = f.FlowerId,
                    FlowerName = f.FlowerName,
                    FlowerPrice = f.FlowerPrice,
                    ImageURL = f.ImageURL
                })
                .ToList();

            

            return View(flowersByCart);

           }


        [HttpPost]
        public IActionResult AddToCart(string userId,
                                       int flowerId,
                                       string flowerName,
                                       double flowerPrice,
                                       string imageUrl)
        {

            this.flowers.AddToCart(userId,flowerId, flowerName, flowerPrice, imageUrl);

            return RedirectToAction(nameof(MyCart));
        }



        [HttpPost]
        public IActionResult Add(FlowerFormModel flower)
        {
            if (!ModelState.IsValid)
            {
                return View(flower);
            }

            this.flowers.Create(flower.FlowerName,
                                flower.FlowerPrice,
                                flower.ImageURL);

            return RedirectToAction(nameof(All));
        } 

        public IActionResult Edit(int id)
        {
            var flower = this.flowers.Details(id);

            return View(new FlowerFormModel
            {
                FlowerName = flower.FlowerName,
                FlowerPrice = flower.FlowerPrice,
                ImageURL = flower.ImageURL
            });
        }
        public IActionResult Delete(int id)
        {
            this.flowers.Delete(id);

            return RedirectToAction(nameof(All));
        }

        public IActionResult DeleteFromCart(int id)
        {
            this.flowers.Delete(id);

            return RedirectToAction(nameof(MyCart));
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
                              flower.ImageURL);

            

            return RedirectToAction(nameof(All));

        }

        public IActionResult MyOrders()
        {
            return View();
        }

        public IActionResult AllOrders()
        {
            return View();
        }
    }
}
