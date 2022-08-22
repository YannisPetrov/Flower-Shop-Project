namespace FlowerShop.Controllers
{
    using System;
    using FlowerShop.Data;
    using FlowerShop.Data.Models;
    using FlowerShop.Infrastructure.Extensions;
    using FlowerShop.Models.Flowers;
    using FlowerShop.Services.Flowers;
    using Microsoft.AspNetCore.Mvc;

    public class FlowersController : Controller
    {
        private readonly IFlowerService flowers;

        public FlowersController(IFlowerService flowers)
        {
            this.flowers = flowers;
        }

        public IActionResult Cart()
        {
            /*var myFlowers = this.flowers.ByUser(this.User.Id());*/
            return View();
        }

        /*public IActionResult Add() => View();*/

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
    }
}
