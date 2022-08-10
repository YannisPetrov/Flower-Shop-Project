namespace FlowerShop.Models.Flowers
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    public class AllFlowersQueryModel
    {
        public const int FlowersPerPage = 3;

        public IEnumerable<string> FlowerName { get; init; }

        [Display(Name = "Search by Text...")]
        public string SearchTerm { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalFlowers { get; set; }
        public FlowerSorting Sorting { get; init; }
        public IEnumerable<FlowerListingViewModel> Flowers { get; set; }
    }
}
