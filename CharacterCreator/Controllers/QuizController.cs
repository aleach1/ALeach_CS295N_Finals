using Microsoft.AspNetCore.Mvc;

namespace CharacterCreator.Controllers
{
    public class QuizController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
