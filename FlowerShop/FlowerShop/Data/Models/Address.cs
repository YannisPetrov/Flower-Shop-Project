namespace FlowerShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Address
    {
        public int AddressId { get; set; }

        [Required]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        [MinLength(3)]
        public string FullName { get; set; }

        [Required]
        [MinLength(5)]
        public string AddressInfo { get; set; }

        [Required]
        [MinLength(2)]
        public string PopulatedPlace { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string PhoneNumber { get; set; }

    }
}
