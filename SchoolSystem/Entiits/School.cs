using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Entiits
{
    public class School
    {
        public int Id { get; set; }
        
        [Required,MaxLength(100)]
        public string Name { get; set; }
        [Required,MaxLength(100)]
        public string Type {  get; set; }

        [Required]
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        Department Department { get; set; }
        public ICollection<Teacher> Teachers { get; set; }

        [InverseProperty("FromSchool")]
        public ICollection<TeacherTransfare> TransfersFrom { get; set; }
        [InverseProperty("ToSchool")]
        public ICollection<TeacherTransfare> TransfersTo { get; set; }

    }
}