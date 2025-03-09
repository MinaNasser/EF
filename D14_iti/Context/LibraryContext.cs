



using D14_iti.Entities;
using Microsoft.EntityFrameworkCore;

namespace D14_iti.Context
{
    public class LibraryContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=DB_Library;Integrated Security=True;TrustServerCertificate=True;");
                //,
                //options => options.EnableRetryOnFailure());
        }



        public virtual  DbSet<Book> Books { get; set; }// IQueyable 
        public virtual  DbSet<Category> Categories { get; set; } 
    }
}
