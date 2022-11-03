namespace FlowerShop.ViewModels
{
    using FlowerShop.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class AddressFormDto
    {

        [Required]
        public string UserId { get; set; }

        [Required]
        [StringLength(55, MinimumLength = 3)]
        [Display(Name = "Full Name...")]
        public string FullName { get; set; }

        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "Address...")]
        public string AddressInfo { get; set; }

        [StringLength(30, MinimumLength = 2)]
        [Display(Name = "Populated place...")]
        public string PopulatedPlace { get; set; }

        [StringLength(10, MinimumLength = 10)]
        [Display(Name = "Phone number...")]
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
