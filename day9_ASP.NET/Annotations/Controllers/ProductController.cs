using Annotation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Annotation.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(ProductModel model)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
