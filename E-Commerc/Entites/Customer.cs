using System.ComponentModel.DataAnnotations;

namespace E_Commerc.Entites
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}