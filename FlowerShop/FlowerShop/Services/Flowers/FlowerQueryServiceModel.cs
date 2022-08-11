namespace FlowerShop.Services.Flowers
{
    public class FlowerQueryServiceModel
    {
        public int CurrentPage { get; init; }
        public int FlowersPerPage { get; init; }

        public int TotalFlowers { get; init; }

        public IEnumerable<FlowerServiceModel> Flowers { get; init; }
    }
}
