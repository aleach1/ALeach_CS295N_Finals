using CharacterCreator.Data;
using CharacterCreator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CharacterCreator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ICharacterRepository _repo;
        public HomeController(ILogger<HomeController> logger, ICharacterRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Characters()
        {
            var chars = _repo.GetAllChars();
            return View(chars);
        }

        [HttpGet]
        public IActionResult Filter(string creator, string date)
        {
            var chars = _repo.GetAllChars()
                .Where(s => creator == null ||(s.Account != null && s.Account.Username == creator))
                .Where(s => date == null || DateOnly.FromDateTime(s.DateCreated) == DateOnly.Parse(date))
                .ToList();

            return View("Characters", chars);
        }

        public IActionResult NewChar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewChar(Character newChar)
        {
            if (_repo.NewChar(newChar) > 0)
            {
                return RedirectToAction("Characters");
            }
            else
            {
                ViewBag.ErrorMessage = "There was an error saving the character.";
                return View();
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
