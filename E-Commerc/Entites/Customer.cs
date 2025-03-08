using System.ComponentModel.DataAnnotations;

namespace E_Commerc.Entites
{
    public class Customer
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MaxLength(15)]
        public string PhoneNumber { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}