using Microsoft.AspNetCore.Mvc;

namespace BookListRazor2.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }

        public string Another()
        {
            return "Another page";
        }
    }
}