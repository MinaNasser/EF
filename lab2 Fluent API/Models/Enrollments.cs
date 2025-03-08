using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_Fluent_API.Models
{
    public class Enrollments
    {
        //public int EnrollmentsId {  get; set; }


        public decimal Grade { get; set; }



        public int StudentId { get; set; }

        public Student Student { get; set; }


        public int CoursId { get; set; }
        public Courses Courses { get; set; }


    }
}
