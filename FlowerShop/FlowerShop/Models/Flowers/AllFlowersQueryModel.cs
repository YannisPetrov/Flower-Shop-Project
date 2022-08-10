namespace FlowerShop.Models.Flowers
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    public class AllFlowersQueryModel
    {
        public IEnumerable<string> FlowerName { get; init; }

        [Display(Name = "Search by Text...")]
        public string SearchTerm { get; init; }

        public FlowerSorting Sorting { get; init; }
        public IEnumerable<FlowerListingViewModel> Flowers { get; init; }
    }
}
