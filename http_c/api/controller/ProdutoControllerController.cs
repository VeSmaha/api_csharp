using api.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace api.Models;

[ApiController]
//sempre q tiver essa notaçao ele vai entender que é pra chamar as rotas http
[Route("api/produto")]//rota raiz

//classe com varias funcionalidades acopladas;
//
public class ProdutoController : ControllerBase
{
    private readonly Context _ctx;//var visivel globalmente (po isso _), apenas leitura

    public ProdutoController(Context ctx){//construtor
      _ctx = ctx;
    }
    private static List<Produto> produtos = new List<Produto>();
    [Route("listar")]//sempre acima do que configurar
    [HttpGet]
    public IActionResult Listar(){
       
        // return _ctx.Produtos.ToList().Count==0? NotFound() : Ok(produtos);
       
       try{
       List<Produto> produtos = _ctx.Produtos.Include(objproduto=>objproduto.Category).ToList();//banco.tabela.relaçao   include(dados da categoria)-> para relaçoes
       return produtos.Count == 0? NotFound():Ok(produtos);

       }catch(Exception e){
          return BadRequest(e.Message);
       }
    }

    
    [HttpPost]
    [Route("cadastrar")]//sempre acima do que configurar

    //Iaction result-> resultado de uma acao
    //injeçao de dependencias
    //ctx chga como parametro pq pega tds a sdependencias automaticamente

      public IActionResult Cadastrar([FromBody]Produto produto){//tudo q for receber da rota(body/paramns) vai nos paramentros
      //sempre procurar o id que é enviado para acdastrar para ver se existe e preencher o campo
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
    [Route("buscar/{ID}")]//sempre acima do que configurar

    //Iaction result-> resultado de uma acao
      public IActionResult Buscar([FromRoute] int ID){//nome do parametro da url deve ser igual nos parametros
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
      
            Produto? produto = _ctx.Produtos.Find(id);//find encontra so pelo id, firstOrDefault pra outraos
            if(produto==null){
              return NotFound();
            }
            _ctx.Produtos.Remove(produto);
            _ctx.SaveChanges();//necessario em add, delete e update
            return Ok(produto);
       
      }

      [HttpPut]
      [Route("alterar/{id}")]

      public IActionResult Atualizar([FromRoute] int id, [FromBody] Produto produto){
      


          //x = objeto utilizado para fazer a comparaçao
          //no caso produtoCadastrado

          //expressao lambda 
          //firstordefault = usado para procurar por tudo,
          //menos pelo id, id usa find
            Produto? produtoCadastrado
             = _ctx.Produtos.FirstOrDefault(x=> x.ProdutoID == id);//find encontra so pelo id, firstOrDefault pra outraos
            
            if(produto==null){
              return NotFound();
            }else{
              produtoCadastrado.Nome = produto.Nome;
              produtoCadastrado.Descricao = produto.Descricao;
              produtoCadastrado.CriadoEm = produto.CriadoEm;
              produtoCadastrado.Preco = produto.Preco;


            _ctx.Produtos.Update(produtoCadastrado);
            _ctx.SaveChanges();//necessario em add, delete e update
            return Ok();
            }
           
       
      }
       





}
