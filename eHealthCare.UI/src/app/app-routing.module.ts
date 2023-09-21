import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router'; 
import { ProductListComponent } from './modules/product/product-list/product-list.component';
import { ProductDetailComponent } from './modules/product/product-detail/product-detail.component';
import { ProductUpdateComponent } from './modules/product/product-update/product-update.component';


const routes: Routes = [
  { path: '', component: ProductListComponent, pathMatch: 'full' },
  {
    path: 'products',
    component: ProductListComponent
  },
  {
    path: 'products/:id',
    component: ProductDetailComponent
  },
  {
    path: 'products/:id/update',
    component: ProductUpdateComponent
  },
  {
    path: 'products/:id/addProduct',
    component: ProductUpdateComponent
  },
] 

@NgModule({
  declarations: [],
  imports: [CommonModule,RouterModule.forRoot(routes)],
  exports: [RouterModule] 
  
})
export class AppRoutingModule { }
