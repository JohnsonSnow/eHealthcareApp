import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'

import { AppComponent } from './app.component';
import { ProductListComponent } from './modules/product/product-list/product-list.component';
import { ProductUpdateComponent } from './modules/product/product-update/product-update.component';
import { ProductDetailComponent } from './modules/product/product-detail/product-detail.component';
import { ModalComponent } from './modules/modal/modal.component';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    ProductListComponent,
    ProductUpdateComponent,
    ProductDetailComponent,
    ModalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
