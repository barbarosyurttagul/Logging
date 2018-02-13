using Northwind.Business.Abstract;
using Northwind.MvcUI.Models;
using System.Web.Mvc;

namespace Northwind.MvcUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: Product
        public ActionResult Index(int? categoryId)
        {
            var products = categoryId.HasValue
                ? _productService.GetListByCategoryId(categoryId.Value)
                : _productService.GetAll();

            var model = new ProductIndexViewModel
            {
                products = products
            };

            return View(model);
        }
    }
}