namespace FlowerShop.ViewModels
{
    using FlowerShop.Data.Models;

    public class AddressDto
    {
        public int AddressId { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string AddressInfo { get; set; }
        public string PopulatedPlace { get; set; }
        public string PhoneNumber { get; set; }

        public Address ToModel()
        {
            Address result = new Address();
            result.UserId = this.UserId;
            result.FullName = this.FullName;
            result.AddressInfo = this.AddressInfo;
            result.PhoneNumber = this.PhoneNumber;
            result.PopulatedPlace = this.PopulatedPlace;

            return result;
        }
    }
}
