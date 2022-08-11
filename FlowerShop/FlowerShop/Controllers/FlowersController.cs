namespace FlowerShop.Controllers
{
    using System;
    using FlowerShop.Data;
    using FlowerShop.Data.Models;
    using FlowerShop.Models.Api.Flowers;
    using FlowerShop.Models.Flowers;
    using FlowerShop.Services.Flowers;
    using Microsoft.AspNetCore.Mvc;

    public class FlowersController : Controller
    {
        private readonly IFlowerService flowers;
        private readonly FlowerShopDbContext data;

        public FlowersController(IFlowerService flowers, FlowerShopDbContext data)
        {
            this.flowers = flowers;
            this.data = data;
        }

        public IActionResult Add() => View();

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
