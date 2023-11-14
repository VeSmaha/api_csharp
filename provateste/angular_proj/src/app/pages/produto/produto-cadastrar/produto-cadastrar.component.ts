import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Categoria } from 'src/app/models/Categoria.model';
import { Produto } from 'src/app/models/Produto.model';

@Component({
  selector: 'app-produto-cadastrar',
  templateUrl: './produto-cadastrar.component.html',
  styleUrls: ['./produto-cadastrar.component.css']
})
export class ProdutoCadastrarComponent {

  nome! : string;

  descricao! : string;

  preco! : number;

  categoryId! : number;

  categorias!: Categoria[];

  constructor(private client:HttpClient, private router: Router){

  }

  ngOnInit(): void {
    this.client
      .get<Categoria[]>("https://localhost:7098/api/categoria/listar")
      .subscribe({
        //A requição funcionou
        next: (categorias) => {
          console.table(categorias);
          this.categorias = categorias;
        },
        //A requição não funcionou
        error: (erro) => {
          console.log(erro);
          
        },
      });
  }

  cadastrar(): void{
    let produto : Produto = {
      nome : this.nome,
      descricao : this.descricao,
      preco : this.preco,
      categoryId: this.categoryId
    };
    console.log("Dados Enviados:", produto);

  const headers = { 'Content-Type': 'application/json' };
    this.client.post<Produto>("https://localhost:7098/api/produto/cadastrar", produto).subscribe({
      //requisisao com sucesso cai aqui no next
      next: (Produto)=>{
        console.table(Produto);
        this.router.navigate(["/pages/produto/listar"]);

      },//caso de erro 
      error:(erro)=>{console.log("Erro: "+ erro)}

    })
  }
 
  }