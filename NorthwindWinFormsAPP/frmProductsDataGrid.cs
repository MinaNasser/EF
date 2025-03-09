using Microsoft.EntityFrameworkCore;
using NorthwindWinFormsAPP.Context;
using NorthwindWinFormsAPP.Entities;

namespace NorthwindWinFormsAPP
{
    public partial class frmProductsGridView : Form
    {
        public frmProductsGridView()
        {
            InitializeComponent();

            this.FormClosing += (sender, e) => Context?.Dispose();
        }

        NorthwindContext Context = new();


        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var Prds = (from p in Context.Products
            //           where p.UnitsInStock ==0
            //           select p).ToList();

            //grdViewPrds.DataSource = Prds;

            Context.Database.EnsureCreated();
            Context.Products.Load(); //Select * from Products into DBSet.Local

            grdViewPrds.DataSource = Context.Products.Local.ToBindingList();

            //List<Product> OutOfStockPrds = Context.Products.Where(P => P.UnitsInStock == 0).ToList();

            //OutOfStockPrds[0].UnitsInStock = 10; //Tracked by Context

            //OutOfStockPrds.RemoveAt(0); //not Tracked

            //OutOfStockPrds.Add(new()); //not Tracked
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            grdViewPrds.EndEdit();

            Context?.SaveChanges();

            grdViewPrds.Refresh();
        }
    }
}
