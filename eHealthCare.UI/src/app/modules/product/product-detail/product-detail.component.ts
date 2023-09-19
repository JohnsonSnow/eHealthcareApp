import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../product';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

  pageTitle = 'product Detail';    
  errorMessage = '';
  product: Product | undefined;    
    
  constructor(private route: ActivatedRoute,    
    private router: Router,    
    private productService: ProductService) { }    

  ngOnInit(): void {    
    const id = this.route.snapshot.paramMap.get('id');    
    if (id) {    
      this.getProduct(id);    
    }    
  }    
    
  getProduct(id: string) {    
    this.productService.getProduct(id).subscribe(    
      product => this.product = product,    
      error => this.errorMessage = <any>error);    
  }    
    
  onBack(): void {    
    this.router.navigate(['/products']);    
  }    

}
