using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_Fluent_API.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }


        public ICollection<Attendances> Attendances { get; set; }
        public ICollection<Enrollments> Enrollments { get; set; }


    }
}
