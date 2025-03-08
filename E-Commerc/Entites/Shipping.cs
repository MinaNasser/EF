using System.ComponentModel.DataAnnotations;

namespace E_Commerc.Entites
{
    public class Shipping
    {
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required, MaxLength(200)]
        public string Address { get; set; }
        [Required]
        public DateTime ShippedDate { get; set; }
        public Order Order { get; set; }
    }
}