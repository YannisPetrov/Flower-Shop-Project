namespace FlowerShop.Controllers
{
    using FlowerShop.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    public class HomeController : Controller
    {
        // Auto-Generated Code

        public IActionResult Index() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}