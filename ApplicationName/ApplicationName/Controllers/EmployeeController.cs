using Microsoft.AspNetCore.Mvc;

namespace ApplicationName.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
