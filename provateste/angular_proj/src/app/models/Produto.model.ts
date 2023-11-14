import { Categoria } from "./Categoria.model";

export interface Produto{

    nome : string;

    descricao : string;
    
    produtoID? : number;
    
    preco:number;

   
    criadoEm?: string; //date caso fosse fazer contas

    category? : Categoria;

    categoryId : number;
   
}