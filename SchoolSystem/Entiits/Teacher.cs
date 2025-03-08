using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Entiits
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required ,MaxLength(100)]
        public string Name { get; set; }
        public  DateTime BD { get; set; }
        [Required ,MaxLength(20)]
        public string NationalID { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        [MaxLength(50)]
        public string Job { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }

        [MaxLength(50)]
        public string Qualification { get; set; }

        public DateTime QualificationDate { get; set; }
        public DateTime HiringDate { get; set; }

        [MaxLength (200)]
        public string Address { get; set; }
        public string Notes {  get; set; }

        [Required ]
        [ForeignKey("School")]
        public int SchoolID { get; set; }
        public  School School { get; set; }

        public ICollection<TeacherTransfare> Transfares { get; set; }



    }
}