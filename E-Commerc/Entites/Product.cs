using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerc.Migrations;

namespace E_Commerc.Entites
{
    public class Product
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int StockQuantity { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<StockHistory> StockHistories { get; set; }
    }
}
