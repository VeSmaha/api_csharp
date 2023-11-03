using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Api.Model;
using Api.Db;
namespace Api.Controllers;


[ApiController]
[Route("api/categoria")]

public class CategoryController : ControllerBase
{
    private readonly Context _ctx;

    public CategoryController(Context ctx){
      _ctx = ctx;
    }
    // private static List<Category> categorias = new List<Category>();
    [Route("listar")]
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
    [Route("cadastrar")]

      public IActionResult Cadastrar([FromBody]Category category){
        _ctx.Categorys.Add(category);
        _ctx.SaveChanges();
        return Created("", category);
    }

}