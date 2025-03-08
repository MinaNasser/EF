using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Entiits
{
    public class TeacherTransfare
    {
        public int Id {  get; set; }



        [ForeignKey("FromSchoolID")]
        public int? FromSchoolID { get; set; }
        [InverseProperty("TransfersFrom")]
        public School FromSchool { get; set; }

        [ForeignKey("ToSchoolID")]
        public int? ToSchoolID { get; set; }
        [InverseProperty("TransfersTo")]
        public School ToSchool { get; set; }


        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public DateTime TransferDate { get; set; }
    }
}