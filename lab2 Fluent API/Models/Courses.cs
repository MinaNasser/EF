namespace lab2_Fluent_API.Models
{
    public class Courses
    {
        public int CourseId {  get; set; }
        public string Name { get; set; }


        public int Cridets { get; set; }



        public int TeacherID { get; set; }
        public Teacher Teatcher { get; set; }

        public int ClassroomID { get; set; }


        public Classrooms Classrooms { get; set; }


        public ICollection<Attendances> Attendances { get; set; }
        public ICollection<Enrollments> Enrollments { get; set; }


    }
}