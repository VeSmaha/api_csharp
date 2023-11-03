import { Component } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Produto } from 'src/app/models/Produto.model';

@Component({
  selector: 'app-produto-listar',
  templateUrl: './produto-listar.component.html',
  styleUrls: ['./produto-listar.component.css']
})
export class ProdutoListarComponent {

  Produtos : Produto[]=[];

  constructor(private client: HttpClient){
    
  }
    ngOnInit(): void{
      console.log('O componente foi carregado');

      this.client.get<Produto[]>("https://localhost:7098/api/produto/listar").subscribe({
        //quando der certo a requisiçao
        next: (Produtos)=>{
          this.Produtos = Produtos;
          console.table(Produtos);

        },//caso de erro 
        error:(erro)=>{console.log("Erro: "+ erro)}
      })
    }
}
