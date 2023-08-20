using System.Net;
using AjaxModal.Models;
using Microsoft.AspNetCore.Mvc;

// Adjust this namespace based on your project structure

namespace AjaxModal.Controllers
{
    public class HomeController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
    }
}
