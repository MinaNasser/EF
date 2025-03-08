

using Microsoft.EntityFrameworkCore;
using SchoolSystem.Entiits;

namespace SchoolSystem.Context
{
    public class SchoolContext : DbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherTransfare> Transfares  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
                  .UseSqlServer("Data source = .; Initial catalog = DB; Integrated security= true; trustservercertificate = true;");
    }
}
