namespace FlowerShop.Data.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string FullName { get; set; }
        public string AddressInfo { get; set; }
        public string PopulatedPlace { get; set; }
        public string PhoneNumber { get; set; }
    }
}
