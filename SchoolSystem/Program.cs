using SchoolSystem.Context;
using SchoolSystem.Entiits;

namespace SchoolSystem
{
    public class Program
    {
        public static void Main()
        {
            using (var context = new SchoolContext())
            {
                // Ensure the database is created
                context.Database.EnsureCreated();

                // 🟢 Add a new department
                var department = new Department { Name = "Computer Science" };
                context.Departments.Add(department);
                context.SaveChanges();
                Console.WriteLine("✅ Department added successfully!");

                // 🟢 Add a new school linked to the department
                var school = new School { Name = "Tech School", Type = "Private", DepartmentID = department.Id };
                context.Schools.Add(school);
                context.SaveChanges();
                Console.WriteLine("✅ School added successfully!");

                // 🟢 Add a new teacher to the school
                var teacher = new Teacher
                {
                    Name = "John Doe",
                    BD = new DateTime(1990, 5, 15),
                    NationalID = "123456789",
                    Code = "T001",
                    Job = "Math Teacher",
                    Phone = "0123456789",
                    Qualification = "MSc in Mathematics",
                    QualificationDate = new DateTime(2015, 6, 1),
                    HiringDate = DateTime.Now,
                    Address = "123 Street, City",
                    Notes = "Experienced teacher",
                    SchoolID = school.Id
                };
                context.Teachers.Add(teacher);
                context.SaveChanges();
                Console.WriteLine("✅ Teacher added successfully!");

                // 🟢 Transfer the teacher to another school
                var newSchool = new School { Name = "Advanced Tech School", Type = "Public", DepartmentID = department.Id };
                context.Schools.Add(newSchool);
                context.SaveChanges();


                Console.WriteLine("✅ New school added!");

                var transfer = new TeacherTransfare
                {
                    TeacherId = teacher.Id,
                    FromSchoolID = school.Id,
                    ToSchoolID = newSchool.Id,
                    TransferDate = DateTime.Now
                };
                context.Transfares.Add(transfer);
                context.SaveChanges();
                Console.WriteLine("✅ Teacher transferred successfully!");

                // 🟢 Display all teachers
                Console.WriteLine("\n📜 Teacher List:");
                var teachers = context.Teachers.ToList();
                foreach (var t in teachers)
                {
                    Console.WriteLine($"👨‍🏫 {t.Name} - {t.Job} - {t.Phone}");
                }
            }
        }
    }
}