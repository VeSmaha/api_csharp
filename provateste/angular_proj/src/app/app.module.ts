import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProdutoListarComponent } from './pages/produto/produto-listar/produto-listar.component';
import { HttpClientModule } from '@angular/common/http';
import { ProdutoCadastrarComponent } from './pages/produto/produto-cadastrar/produto-cadastrar.component';
import { ProdutoAtualizarComponent } from './pages/produto/produto-atualizar/produto-atualizar.component';

@NgModule({
  declarations: [
    AppComponent,
    ProdutoListarComponent,
    ProdutoCadastrarComponent,
    ProdutoAtualizarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
