namespace lab2_Fluent_API.Models
{
    public class Classrooms
    {
        public int ClassroomId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public string Location {  get; set; }

        public ICollection<Courses> Courses { get; set; }

    }
}