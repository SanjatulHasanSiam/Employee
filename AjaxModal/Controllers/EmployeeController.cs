using Microsoft.AspNetCore.Mvc;

namespace AjaxModal.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
