using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Entiits
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public ICollection<School> Schools { get; set; }

    }
}