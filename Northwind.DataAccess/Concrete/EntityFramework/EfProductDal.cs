using Msb.Core.DataAccess.EntityFramework;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework.Contexts;
using Northwind.Entities.Entity;

namespace Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfBaseEntityRepository<Product, NorthwindContext>, IProductDal
    {
        public override void DeleteContext(Product entity, NorthwindContext context)
        {
            entity.ProductName = "Silindi";
            Update(entity);
        }
    }
}
