using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Api.Model;

public class Category{

    public Category()=> CriadoEm = DateTime.Now;
    public int categoryId { get; set; }

    public string? Nome { get; set; }

    public DateTime? CriadoEm { get; set; }
    
}