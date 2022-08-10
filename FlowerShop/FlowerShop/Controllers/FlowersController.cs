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

        public IActionResult All([FromQuery] AllFlowersQueryModel query)
        {

            var flowersQuery = this.data.Flowers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                flowersQuery = flowersQuery.Where(f =>
                f.FlowerName.ToLower().Contains(query.SearchTerm.ToLower()));
            }

            var totalFlowers = flowersQuery.Count();

            var flowers = flowersQuery
                .Skip((query.CurrentPage - 1) * AllFlowersQueryModel.FlowersPerPage)
                .Take(AllFlowersQueryModel.FlowersPerPage)
                .Select(f => new FlowerListingViewModel
                {
                    Id = f.Id,
                    FlowerName = f.FlowerName,
                    FlowerPrice = f.FlowerPrice,
                    ImageURL = f.ImageURL
                })
                .ToList();

            query.TotalFlowers = totalFlowers;
            query.Flowers = flowers;

            return View(query);
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
