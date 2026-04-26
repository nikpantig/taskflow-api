using Microsoft.AspNetCore.Mvc;

namespace TaskFlow.API.Controllers
{
    public class TasksViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
