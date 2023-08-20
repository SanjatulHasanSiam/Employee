using System.ComponentModel.DataAnnotations;

namespace AjaxModal.Models;

public class Designation
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Designation is required.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Salary is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Salary must be a valid positive number.")]
    public decimal Salary { get; set; }
}