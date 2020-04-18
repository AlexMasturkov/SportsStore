using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpotsStore.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Products);
        }
        public ViewResult Edit(int productId)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            TempData["myTempImageData"] = product.ImageData;
            TempData["myTempProductData"] = product.ProductData;

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase image, HttpPostedFileBase productDataFile)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                    product.ImageDataFileName = image.FileName;
                }
                else
                {
                    product.ImageData = (byte[])TempData["myTempImageData"];
                }

                if (productDataFile != null)
                {
                    product.ProductMimeType = productDataFile.ContentType;
                    product.ProductData = new byte[productDataFile.ContentLength];
                    productDataFile.InputStream.Read(product.ProductData, 0, productDataFile.ContentLength);
                    product.ProductDataFileName = productDataFile.FileName;
                }
                else
                {
                    product.ProductData = (byte[])TempData["myTempProductData"];
                }

                // save the product
                repository.SaveProduct(product);
                // add a message to the viewbag
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                // return the user to the list
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(product);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Product());
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product prod = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (prod != null)
            {
                repository.DeleteProduct(prod);
                TempData["message"] = string.Format("{0} was deleted", prod.Name);
            }
            return RedirectToAction("Index");
        }






    }
}