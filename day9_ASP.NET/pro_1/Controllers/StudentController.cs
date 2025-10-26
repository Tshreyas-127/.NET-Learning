using Microsoft.AspNetCore.Mvc;
using Pro1.Models;
namespace Pro1.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Display()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Display(Employeemodel model)
        {
            if (ModelState.IsValid)
            {
                RedirectToAction("Index");
            }
            return View(model);
        }

    }
}
