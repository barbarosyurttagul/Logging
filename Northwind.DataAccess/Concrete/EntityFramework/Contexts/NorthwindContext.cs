using Northwind.Entities.Entity;
using System.Data.Entity;

namespace Northwind.DataAccess.Concrete.EntityFramework.Contexts
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext() : base("connStr")
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
