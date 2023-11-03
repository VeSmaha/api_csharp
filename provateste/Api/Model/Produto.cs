using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Api.Model;
public class Produto
{
    public Produto()=> CriadoEm = DateTime.Now;
    public int ProdutoID { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }

    public DateTime CriadoEm { get; set; }

    public Category? Category { get; set; }

    public int categoryId { get; set; }
    
}