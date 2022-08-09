﻿namespace FlowerShop.Models.Flowers
{
    using System.ComponentModel.DataAnnotations;
    public class AddFlowerFormModel
    {
        [Required]
        [Display(Name = "Flower Name")]
        [StringLength(15,MinimumLength = 3)]
        public string FlowerName { get; init; }

        [Required]
        [Display(Name = "Price")]
        public double FlowerPrice { get; init; }

        [Required]
        [Display(Name = "Image URL")]
        [Url]
        public string ImageURL { get; init; }
    }
}
