using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Model;
using Api.Db;
namespace Api.Controllers;

[ApiController]
[Route("api/produto")]


public class ProdutoController : ControllerBase
{
    private readonly Context _ctx;

    public ProdutoController(Context ctx){
      _ctx = ctx;
    }
    // private static List<Produto> produtos = new List<Produto>();
    [Route("listar")]
    [HttpGet]
    public IActionResult Listar(){
       
        
       try{
       List<Produto> produtos = _ctx.Produtos.Include(objproduto=>objproduto.Category).ToList();
       return produtos.Count == 0? NotFound():Ok(produtos);

       }catch(Exception e){
          return BadRequest(e.Message);
       }
    }

    
    [HttpPost]
    [Route("cadastrar")]

      public IActionResult Cadastrar([FromBody]Produto produto){
       try{
       
        Category categoria = _ctx.Categorys.Find(produto.categoryId);
        if(categoria==null){
          return NotFound();
        }
          produto.Category = categoria;
          _ctx.Produtos.Add(produto);
          _ctx.SaveChanges();
        // produtos.Add(produto);
        return Created("", produto);
       }catch(Exception e){

        return BadRequest(e.Message);
       }
    }

    [HttpGet]
    [Route("buscar/{ID}")]
      public IActionResult Buscar([FromRoute] int ID){
       foreach (Produto produto in _ctx.Produtos.ToList())
       {
        if(produto.ProdutoID==ID){
            return Ok(produto);
         }
       }
       return NotFound();

       
    }

      [HttpDelete]
      [Route("deletar/{id}")]

      public IActionResult Deletar([FromRoute] int id){
      
            Produto? produto = _ctx.Produtos.Find(id);
            if(produto==null){
              return NotFound();
            }
            _ctx.Produtos.Remove(produto);
            _ctx.SaveChanges();
            return Ok(produto);
       
      }

      [HttpPut]
      [Route("alterar/{id}")]

      public IActionResult Atualizar([FromRoute] int id, [FromBody] Produto produto){
      
            Produto? produtoCadastrado
             = _ctx.Produtos.FirstOrDefault(x=> x.ProdutoID == id);
            
            if(produto==null){
              return NotFound();
            }else{
              produtoCadastrado.Nome = produto.Nome;
              produtoCadastrado.Descricao = produto.Descricao;
              produtoCadastrado.CriadoEm = produto.CriadoEm;
              produtoCadastrado.Preco = produto.Preco;


            _ctx.Produtos.Update(produtoCadastrado);
            _ctx.SaveChanges();
            return Ok();
            }
           
       
      }
       





}
