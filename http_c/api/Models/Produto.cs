using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace api.Models;
public class Produto
{
    public Produto()=> CriadoEm = DateTime.Now;
    public int ProdutoID { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }

    //pode deixar relacionamento em so uma das classes ou nos dois
    // sempre nome da tela e nao categoryid por exemplo
    public DateTime CriadoEm { get; set; }

    public Category? Category { get; set; }

    public int categoryId { get; set; }
    
}