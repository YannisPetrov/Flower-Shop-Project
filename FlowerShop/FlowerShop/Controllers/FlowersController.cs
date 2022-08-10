namespace FlowerShop.Controllers
{
    using System;
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

        public IActionResult All(string searchTerm)
        {

            var flowersQuery = this.data.Flowers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                flowersQuery = flowersQuery.Where(f =>
                f.FlowerName.ToLower().Contains(searchTerm.ToLower()));
            }

            var flowers = flowersQuery
                .OrderByDescending(f => f.Id)
                .Select(f => new FlowerListingViewModel
                {
                    Id = f.Id,
                    FlowerName = f.FlowerName,
                    FlowerPrice = f.FlowerPrice,
                    ImageURL = f.ImageURL
                })
                .ToList();

            return View(new AllFlowersQueryModel
            {
                Flowers = flowers,
                SearchTerm = searchTerm
            });
        }

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

            return RedirectToAction(nameof(All));
        } 
    }
}
