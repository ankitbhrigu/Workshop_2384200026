using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
