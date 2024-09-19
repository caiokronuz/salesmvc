using Microsoft.AspNetCore.Mvc;

namespace salesmvc.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
