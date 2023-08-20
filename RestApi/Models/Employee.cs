using AjaxModal.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RestApi.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please provide a name")]
        [StringLength(50,ErrorMessage ="Name must be in 50 charachters")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please provide a valid email")]
        public string Email { get; set; }

        [ValidateNever]
        [ForeignKey("DesignationId")]
        public virtual Designation Designation { get; set; }
        [ValidateNever]
        [DisplayName("Designation")]
        public int DesignationId { get; set; }
    }
}
