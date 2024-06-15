using Microsoft.EntityFrameworkCore;

namespace Lab13S13.Models
{
    public class DbSemana13 : DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Details> Details { get; set; }
        public DbSet<Invoices> Invoices { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAB1504-30\\SQLEXPRESS; " + "Initial Catalog=DbSemana13; Integrated Security=True;trustservercertificate=True");
        }
    }
}
