using D14_iti.Context;
using D14_iti.Entities;

namespace D14_iti
{
    public class Program
    {
        public static void Main()
        {

            using LibraryContext db = new();

            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();
            #region Insert

            //db.Categories.Add(new() {Name= "SciFiction"});
            //db.Categories.Add(new() {Name= "Historical"});

            //Console.WriteLine($"Local Categories {db.Categories.Local.Count} ");
            //Console.WriteLine($"DB Berfor  Categories {db.Categories.Count()} ");


            //Book book = new()
            //{
            //    Title = "Test Title",
            //    Description = "Test Description",
            //    Price = 10,
            //    PromotionPrice = 9,
            //    CategoryId = 1

            //};

            //db.Add(book);
            // add to offline local cath
            //Commit changes
            //int r = db.SaveChanges();

            //Console.WriteLine($"DB After  Categories {db.Categories.Count()} ");


            //Console.WriteLine($"Number Of Row Effectied {r}");
            // old Version of Using
            //using (LibraryContext context = new LibraryContext())
            //{
            //    context.Database.EnsureCreated();

            //}

            //LibraryContext context=null;
            //try
            //{
            //    context = new LibraryContext();
            //}
            //finally
            //{
            //    context?.Dispose();//reales Unmanaged Resources
            //} 
            #endregion
            #region Select
            var G = (from c in db.Categories
                    where c.Name.Contains("Sci")
                    select c).FirstOrDefault();
            if (G != null)
            {
                G.Name = "Science Fiction";
            }


            db.SaveChanges();
            #endregion
        }
    }
}