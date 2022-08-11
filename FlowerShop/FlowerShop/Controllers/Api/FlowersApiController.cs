﻿namespace FlowerShop.Controllers.Api
{
    using FlowerShop.Data;
    using FlowerShop.Models.Api.Flowers;
    using FlowerShop.Services.Flowers;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/flowers")]
    public class FlowersApiController : ControllerBase
    {
        private readonly IFlowerService flowers;

        public FlowersApiController(IFlowerService flowers) =>
            this.flowers = flowers;

        [HttpGet]
        public FlowerQueryServiceModel All([FromQuery] AllFlowersApiRequestModel query)
            =>  this.flowers.All(
                query.SearchTerm,
                query.CurrentPage,
                query.FlowersPerPage
                );
        
    }
}
