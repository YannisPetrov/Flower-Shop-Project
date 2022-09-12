﻿namespace FlowerShop.Models.Flowers
{
    using System.ComponentModel.DataAnnotations;
    public class FlowerFormModel
    {
        [Required]
        [Display(Name = "Flower Name")]
        [StringLength(35,MinimumLength = 3)]
        public string FlowerName { get; init; }

        [Required]
        [Display(Name = "Price")]
        public double FlowerPrice { get; init; }

        [Required]
        [Display(Name = "Image URL")]
        [Url]
        public string ImageURL { get; init; }

        [Required]
        [Display(Name = "Information about the flower...")]
        [StringLength(850, MinimumLength = 50)]
        public string Info { get; init; }
    }
}
