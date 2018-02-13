using Northwind.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Abstract
{
    public interface IProductService
    {
        Product Insert(Product product);

        void Delete(int productId);

        List<Product> GetAll();

        List<Product> GetListByCategoryId(int categoryId);

        Product GetById(int productId);

        Product Update(Product product);
    }
}
