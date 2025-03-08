﻿using System.ComponentModel.DataAnnotations;

namespace E_Commerc.Entites
{
    public class StockHistory
    {
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public DateTime ChangeDate { get; set; } = DateTime.Now;
        [Required]
        public int QuantityChanged { get; set; }
        public Product Product { get; set; }
    }
}