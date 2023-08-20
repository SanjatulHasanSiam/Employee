using AjaxModal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace AjaxModal.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly HttpClient _httpClient;

        public EmployeeController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7180/api/v1/"); // Replace with the API's base URL
        }
        public async Task<IActionResult> Index()
        {

            HttpResponseMessage response = await _httpClient.GetAsync("designations"); // Replace with the actual API endpoint
            
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadFromJsonAsync<List<DesignationViewModel>>();
                // Process responseData...
                var vm = new EmployeeViewModel()
                {
                    Designations = responseData!
                };
                return View(vm);
            }
            return View(null);
        }

    }
}
