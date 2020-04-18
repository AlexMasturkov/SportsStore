using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;
using System.Linq;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public int PageSize = 4;
        private IProductRepository repository;


        public ProductController(IProductRepository productRepository)
        {
            repository = productRepository;
        }

        public ViewResult List(string category,int page = 1)
        {
            ProductsListViewModel viewModel = new ProductsListViewModel
            {
                Products = repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?repository.Products.Count():repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(viewModel);
        }
        public FileContentResult GetImage(int productId)
        {
            Product prod = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
        public FileResult GetFileForDownload(int productId)
        {
            Product prod = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (prod != null)
            {
                return File(prod.ProductData, prod.ProductMimeType, prod.ProductDataFileName);
            }
            else
            {
                return null;
            }
        }


        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
    }
}