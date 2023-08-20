using AjaxModal.Models;
using Microsoft.AspNetCore.Mvc;
using RestApi.DataAccess;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DesignationsController : ControllerBase
    {
       // private static readonly List<Designation> Designations = new List<Designation>();
        private readonly ApplicationDbContext _context;
        public DesignationsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/v1/Designation
        [HttpGet]
        public IEnumerable<Designation> GetDesignations()
        {
            try
            {
                List<Designation> Designations = _context.Designations.ToList();
                return Designations;
            }
            catch(Exception ex)
            {
                throw;
            }
            
            
        }

        // GET: api/v1/Designation/5
        [HttpGet("{id}")]
        public IActionResult GetDesignation(int id)
        {

            var designation = _context.Designations.FirstOrDefault(p => p.Id == id);
            if (designation == null)
            {
                return NotFound();
            }
            return Ok(designation);
        }

        // POST: api/v1/Designation
        [HttpPost]
        public IActionResult PostDesignation(Designation designation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Generate a unique ID for the new Designation
            int nextId = 1;
            List<Designation> Designations = _context.Designations.ToList();
            if (Designations.Any())
            {
                nextId = Designations.Max(p => p.Id) + 1;
            }

            designation.Id = nextId;
            _context.Designations.Add(designation);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetDesignation), new { id = designation.Id }, designation);
        }

        // PUT: api/v1/Designation/5
        [HttpPut("{id}")]
        public IActionResult PutDesignation(int id, Designation designation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingDesignation = _context.Designations.FirstOrDefault(p => p.Id == id);
            if (existingDesignation == null)
            {
                return NotFound();
            }

            existingDesignation.Title = designation.Title;
            existingDesignation.Salary = designation.Salary;
            _context.Designations.Update(existingDesignation);
            _context.SaveChanges();
            return Ok(existingDesignation);
        }

        // DELETE: api/v1/Designation/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDesignation(int id)
        {
            var designation = _context.Designations.FirstOrDefault(p => p.Id == id);
            if (designation == null)
            {
                return NotFound();
            }

            _context.Designations.Remove(designation);
            _context.SaveChanges();
            return Ok(designation);
        }
    }
}
