import { Component, OnInit } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { Product } from '../product';
import { ProductService } from '../product.service';
import * as signalR from '@microsoft/signalr';
import { SignalrService } from '../../../service/signalr.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  performFilter(filterBy: string): Product[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.products.filter((product: Product) => product.name.toLocaleLowerCase().indexOf(filterBy) !== -1);
  }
  pageTitle = 'Product List';
  filteredProducts: Product[] = [];
  products: Product[] = [];
  errorMessage = '';
  _listFilter = '';

  get listFilter(): string {
    return this._listFilter;
  }

  set listFilter(value: string) {
    this._listFilter = value;
    this.filteredProducts = this.listFilter ? this.performFilter(this.listFilter) : this.products
  }

  constructor(private productService: ProductService, private signalrService: SignalrService) {
    this.getProductData();
    this.signalrService.startConnection();
    this.signalrService.addProductListener();  
  }

  ngOnInit(): void {
   
  }

  getProductData() {
    this.productService.getProducts().subscribe(
      products => {
        this.products = products;
        this.filteredProducts = this.products;
      },
      error => this.errorMessage = <any>error
    );
  }

  deleteProduct(id: string, name: string): void {
    if (id === '') {
      this.onSaveComplete();
    } else {
      if (confirm(`Are you sure want to delete this Product: ${name}?`)) {
        this.productService.deleteProduct(id)
          .subscribe(
            () => this.onSaveComplete(),
            (error: any) => this.errorMessage = <any>error
          );
      }
    }
  }

  onSaveComplete(): void {
    this.productService.getProducts().subscribe(
      products => {
        this.products = products;
        this.filteredProducts = this.products;
      },
      error => this.errorMessage = <any>error
    );
  } 

}
