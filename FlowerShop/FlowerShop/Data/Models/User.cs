namespace FlowerShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    using static DataConstants.User;

    public class User : IdentityUser
    {
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; }

        public ICollection<Cart> Cart { get; set; }
        public ICollection<Orders> Orders { get; set; }

    }
}
