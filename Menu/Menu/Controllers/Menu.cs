using Microsoft.AspNetCore.Mvc;
using Menu.Dto;
using Menu.Models;

namespace Menu.Controllers
{
    public class Menu : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
