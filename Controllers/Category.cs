using Microsoft.AspNetCore.Mvc;

namespace BulkyWebC_.Controllers
{
    public class Category : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
