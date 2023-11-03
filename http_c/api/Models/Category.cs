using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace api.Models;

public class Category{

    public Category()=> CriadoEm = DateTime.Now;
    public int categoryId { get; set; }

    public string? Nome { get; set; }

    public DateTime? CriadoEm { get; set; }
    
}