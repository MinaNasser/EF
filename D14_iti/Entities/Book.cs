using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D14_iti.Entities
{
    public class Book
    {
        /// <summary>
        /// Mapping 
        /// 
        /// 1- EF Convensions // default
        /// 2- Data Annotations  // access in code 
        /// 3- Fluent API // OnModelCreating // don't have access
        /// 4- Configration Classes
        /// </summary>
        /// 

        [Key]
        public int  Id{ get; set; }
        [MaxLength(100),Required]
        public  string Title{ get; set; }
        public string? Description{ get; set; }// allow null by ? 
        [Column(TypeName = "Money")]
        public decimal Price{ get; set; }
        [Column(TypeName = "Money")]
        public decimal? PromotionPrice{ get; set; }
        [NotMapped]// Ignore 
        public DateTime? CreatedDate{ get; set; } = DateTime.Now;

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }




    }
}
