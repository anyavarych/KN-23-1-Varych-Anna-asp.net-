using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Default.Default.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
