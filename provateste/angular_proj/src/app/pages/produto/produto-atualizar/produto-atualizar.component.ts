import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Categoria } from 'src/app/models/Categoria.model';
import { Produto } from 'src/app/models/Produto.model';

@Component({
  selector: 'app-produto-atualizar',
  templateUrl: './produto-atualizar.component.html',
  styleUrls: ['./produto-atualizar.component.css']
})
export class ProdutoAtualizarComponent {
  produtoID!: number;

  nome! : string;

  descricao! : string;

  preco! : number;

  categoryId! : number;

  categorias!: Categoria[];

  constructor(private client:HttpClient, private router: Router, private route: ActivatedRoute){

  }
  ngOnInit(): void {
    this.route.params.subscribe({
      next: (parametros) => {
        let { id } = parametros;
        this.client
          .get<Produto>(
            `https://localhost:7098/api/produto/buscar/${id}`
          )
          .subscribe({
            next: (produto) => {
              this.client
                .get<Categoria[]>(
                  "https://localhost:7098/api/categoria/listar"
                )
                .subscribe({
                  next: (categorias) => {
                    this.categorias = categorias;

                    this.produtoID = produto.produtoID!;
                    this.nome = produto.nome;
                    this.descricao = produto.descricao;
                    this.preco = produto.preco;
                    this.categoryId = produto.categoryId;
                  },
                  error: (erro) => {
                    console.log(erro);
                  },
                });
            },
            //Requisição com erro
            error: (erro) => {
              console.log(erro);
            },
          });
      },
    });
 
  
  }
  alterar(): void {
    let produto: Produto = {
      nome: this.nome,
      descricao: this.descricao,
      preco: this.preco!,
      categoryId: this.categoryId,
    };

    console.log(produto);

    this.client
      .put<Produto>(
        `https://localhost:7098/api/produto/alterar/${this.produtoID}`,
        produto
      )
      .subscribe({
        //A requição funcionou
        next: (produto) => {
          this.router.navigate(["pages/produto/listar"]);
          
          
        },
        //A requição não funcionou
        error: (erro) => {
          console.log(erro);
        },
      });
  }
}
