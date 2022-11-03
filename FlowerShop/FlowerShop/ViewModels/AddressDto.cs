namespace FlowerShop.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using FlowerShop.Data.Models;

    public class AddressDto
    {
        public int AddressId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string AddressInfo { get; set; }

        [Required]
        public string PopulatedPlace { get; set; }

        [Required]
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
