using AjaxModal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi.Models;

namespace RestApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private static readonly List<Employee> Employees = new List<Employee>();

        // GET: api/v1/Employee
        [HttpGet]
        public IEnumerable<Employee> GetEmployees()
        {
            return Employees;
        }

        // GET: api/v1/Employee/5
        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = Employees.FirstOrDefault(p => p.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // POST: api/v1/Employee
        [HttpPost]
        public IActionResult PostEmployee([Bind("Id,Name,DesignationId")] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Generate a unique ID for the new Employee
            int nextId = 1;
            if (Employees.Any())
            {
                nextId = Employees.Max(p => p.Id) + 1;
            }

            employee.Id = nextId;
            Employees.Add(employee);

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        // PUT: api/v1/Employee/5
        [HttpPut("{id}")]
        public IActionResult PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingEmployee = Employees.FirstOrDefault(p => p.Id == id);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            existingEmployee.Name = employee.Name;
            existingEmployee.Email = employee.Email;
            employee.DesignationId = employee.DesignationId;

            return Ok(existingEmployee);
        }

        // DELETE: api/v1/Employee/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = Employees.FirstOrDefault(p => p.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            Employees.Remove(employee);
            return Ok(employee);
        }
    }
}
