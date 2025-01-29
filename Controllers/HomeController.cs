using Microsoft.AspNetCore.Mvc;
using To_do_List.Models;

namespace To_do_List.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public IActionResult Create(Models.Task task)
        {
           return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            // Lógica para obtener y mostrar las tareas
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
