using Microsoft.AspNetCore.Mvc;

namespace CharacterCreator.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
