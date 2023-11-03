using api.data;
using Microsoft.AspNetCore.Mvc;
namespace api.Models;

[ApiController]
//sempre q tiver essa notaçao ele vai entender que é pra chamar as rotas http
[Route("api/categoria")]//rota raiz

//classe com varias funcionalidades acopladas;
//
public class CategoryController : ControllerBase
{
    private readonly Context _ctx;//var visivel globalmente (po isso _), apenas leitura

    public CategoryController(Context ctx){//construtor
      _ctx = ctx;
    }
    private static List<Category> categorias = new List<Category>();
    [Route("listar")]//sempre acima do que configurar
    [HttpGet]
    public IActionResult Listar(){
       
       try{
       List<Category> categorias = _ctx.Categorys.ToList();
       return categorias.Count == 0? NotFound():Ok(categorias);
       }catch(Exception e){
          return BadRequest(e.Message);
       }
    }

    
    [HttpPost]
    [Route("cadastrar")]//sempre acima do que configurar

    //Iaction result-> resultado de uma acao
    //injeçao de dependencias
    //ctx chga como parametro pq pega tds a sdependencias automaticamente

      public IActionResult Cadastrar([FromBody]Category category){//tudo q for receber da rota(body/paramns) vai nos paramentros
        _ctx.Categorys.Add(category);
        _ctx.SaveChanges();
        // produtos.Add(produto);
        return Created("", category);
    }

}