using AjaxModal.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AjaxModal.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            var vm = new EmployeeViewModel()
            {
                Designations = new List<DesignationViewModel>
                {
                    new(){Id = 1,Title="ABC"},
                    new(){Id = 2,Title="BCF"},

                }
            };
            return View(vm);
        }
    }
}
