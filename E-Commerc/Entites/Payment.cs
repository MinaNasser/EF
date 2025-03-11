using System.ComponentModel.DataAnnotations;

namespace E_Commerc.Entites
{
    public class Payment
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public string PaymentMethod { get; set; }

        public bool IsPaid { get; set; } = false;
        public virtual Order Order { get; set; }
    }
}