using Msb.Core.CrossCuttingConcerns.Logging;
using Northwind.Business.Abstract;
using Northwind.DataAccess.Abstract;
using Northwind.Entities.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;       
        private readonly ILogManager _logManager;

        public ProductManager(IProductDal productDal, 
                              ILogManager logManager)
        {
            _productDal = productDal;     
            _logManager = logManager;
        }

        public Product Insert(Product product)
        {
            return _productDal.Insert(product);
        }

        public void Delete(int productId)
        {
            var product = GetById(productId);
            _productDal.Delete(product);  
        }

        public List<Product> GetAll()
        {
            _logManager.Info("Ürün Listesi getirildi");

            return _productDal.GetAll();
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

        public List<Product> GetListByCategoryId(int categoryId)
        {
            return GetAll().Where(p => p.CategoryId == categoryId).ToList();
        }

        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }
    }
}
