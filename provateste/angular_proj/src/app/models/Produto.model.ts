export interface Produto{
    // ProdutoID : Int;
    nome : string;
    descricao : string;
    
    produtoID? : number;
    
    preco:number;

   
    criadoEm?: string; //date caso fosse fazer contas

    // Category? : Category;

   categoryId : number;
   
}