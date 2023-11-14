import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProdutoAtualizarComponent } from './pages/produto/produto-atualizar/produto-atualizar.component';
import { ProdutoListarComponent } from './pages/produto/produto-listar/produto-listar.component';
import { ProdutoCadastrarComponent } from './pages/produto/produto-cadastrar/produto-cadastrar.component';

const routes: Routes = [
  {
    path : "",
    component: ProdutoListarComponent
  },
  {
    path : "pages/produto/listar",
    component: ProdutoListarComponent
  },
  {
    path : "pages/produto/cadastrar",
    component: ProdutoCadastrarComponent
  },
  {
    path: "pages/produto/alterar/:id",
    component: ProdutoAtualizarComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
