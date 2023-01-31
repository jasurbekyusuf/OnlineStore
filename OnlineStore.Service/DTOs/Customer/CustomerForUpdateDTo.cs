using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Service.DTOs.Customer
{
    public class CustomerForUpdateDTo
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
