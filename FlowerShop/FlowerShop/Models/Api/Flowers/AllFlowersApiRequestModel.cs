namespace FlowerShop.Models.Api.Flowers
{
    public class AllFlowersApiRequestModel
    {

        public IEnumerable<string> FlowerName { get; init; }

        public string SearchTerm { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int FlowersPerPage { get; init; } = 10;


    }
}
