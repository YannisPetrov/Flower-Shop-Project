namespace FlowerShop.ViewModels
{
    using FlowerShop.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class AddressFormDto
    {

        [Required]
        public string UserId { get; set; }

        [MinLength(5)]
        [Required]
        public string FullName { get; set; }
        public string AddressInfo { get; set; }
        public string PopulatedPlace { get; set; }
        public string PhoneNumber { get; set; }

        public Address ToModel()
        {
            Address result = new Address();
            result.UserId = UserId;
            result.FullName = FullName;
            result.AddressInfo = AddressInfo;
            result.PhoneNumber = PhoneNumber;
            result.PopulatedPlace = PopulatedPlace;

            return result;
        }
    }
}
