namespace FlowerShop.Controllers
{
    using FlowerShop.Data;
    using FlowerShop.Data.Models;
    using FlowerShop.Models.Flowers;
    using Microsoft.AspNetCore.Mvc;

    public class FlowersController : Controller
    {

        private readonly FlowerShopDbContext data;

        public FlowersController(FlowerShopDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(AddFlowerFormModel flower)
        {
            if (!ModelState.IsValid)
            {
                return View(flower);
            }

            var flowerData = new Flower
            {
                FlowerName = flower.FlowerName,
                FlowerPrice = flower.FlowerPrice,
                ImageURL = flower.ImageURL
            };

            this.data.Flowers.Add(flowerData);

            this.data.SaveChanges();

            return RedirectToAction("Index" ,"Home");
        } 
    }
}
