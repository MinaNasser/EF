namespace lab2_Fluent_API.Models
{
    public class Teacher
    {
        public int TeacherId  { get; set; }

        public string Name { get; set; }    

        public string Subject { get; set; } 

        public string Email { get; set; }

        public string phone {  get; set; }

        public ICollection<Courses> Courses { get; set; }

    }
}