using System.ComponentModel.DataAnnotations;

namespace E_Commerc.Entites
{
    public class Payment
    {
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required, MaxLength(50)]
        public string PaymentMethod { get; set; }
        [Required]
        public bool IsPaid { get; set; } = false;
        public Order Order { get; set; }
    }
}