namespace FlowerShop.Models.Flowers
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using FlowerShop.Services.Flowers;

    public class AllFlowersQueryModel
    {
        public const int FlowersPerPage = 6;

        public IEnumerable<string> FlowerName { get; init; }

        [Display(Name = "Search by Text...")]
        public string SearchTerm { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalFlowers { get; set; }
        public FlowerSorting Sorting { get; init; }
        public IEnumerable<FlowerServiceModel> Flowers { get; set; }
    }
}
