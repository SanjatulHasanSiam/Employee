using System.ComponentModel.DataAnnotations;

namespace AjaxModal.Models;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }
}