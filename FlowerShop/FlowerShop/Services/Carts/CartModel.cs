﻿namespace FlowerShop.Services.Carts
{
    using FlowerShop.Services.Addresses;
    public class CartModel
    {
        public int CartId { get; set; }
        public string UserId { get; set; }
        public int FlowerId { get; set; }
        public string FlowerName { get; init; }
        public double FlowerPrice { get; init; }
        public string ImageURL { get; init; }
        public IEnumerable<AddressModel> Addresses { get; init; }
    }
}
