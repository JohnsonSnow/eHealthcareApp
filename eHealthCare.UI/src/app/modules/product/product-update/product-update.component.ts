import { Component, ElementRef, OnDestroy, OnInit, ViewChildren } from '@angular/core';
import { FormControlName, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Product } from '../product';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-update',
  templateUrl: './product-update.component.html',
  styleUrls: ['./product-update.component.css']
})
export class ProductUpdateComponent implements OnInit, OnDestroy {
  @ViewChildren(FormControlName, { read: ElementRef })
    formInputElements!: ElementRef[];
  pageTitle = 'Product Update';
  errorMessage!: string;
  productForm!: FormGroup;
  tranMode!: string;
  product!: Product;
  private sub!: Subscription;

  displayMessage: { [key: string]: string } = {};
  private validationMessages: { [key: string]: { [key: string]: string } };  

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private productService: ProductService) {

    this.validationMessages = {
      name: {
        required: 'Product name is required.',
        minlength: 'Product name must be at least three characters.',
        maxlength: 'Product name cannot exceed 50 characters.'
      },
     
    };
  }  

  ngOnInit(): void {
    this.tranMode = "new";
    this.productForm = this.fb.group({
      name: ['', [Validators.required,
      Validators.minLength(3),
      Validators.maxLength(50)
      ]],
      classifications: '',
      competentAuthorityStatus: '',
      internalStatus: '',
      unit: '',
      activeIngredients: '',
      pharmaceuticalForms: '',
      therapeuticClass: '',
      atcCode: '',
      activeIngredientID: 0,
      pharmaceuticalFormID: 0,
      productUnitID: 0,
      atcCodeID: 0,
      therapeuticClassID: 0 
    });

    this.sub = this.route.paramMap.subscribe(
      params => {
        const id = params.get('id');
        if (id == '0') {
          const product: Product = {
            id: "0",
            name: "",
            classifications: '',
            competentAuthorityStatus: '',
            internalStatus: '',
            unit: '',
            activeIngredients: '',
            pharmaceuticalForms: '',
            therapeuticClass: '',
            atcCode: '',
            activeIngredientID: 0,
            pharmaceuticalFormID: 0,
            productUnitID: 0,
            atcCodeID: 0,
            therapeuticClassID: 0 
          };
          this.displayProduct(product);
        }
        else {
          this.getEmployee(id!);
        }
      }
    );  
  }


  getEmployee(id: string): void {
    this.productService.getProduct(id)
      .subscribe(
        (product: Product) => this.displayProduct(product),
        (error: any) => this.errorMessage = <any>error
      );
  }

  displayProduct(product: Product): void {
    if (this.productForm) {
      this.productForm.reset();
    }
    this.product = product;
    if (this.product.id == '0') {
      this.pageTitle = 'Add Product';
    } else {
      this.pageTitle = `Update Product: ${this.product.name}`;
    }
    this.productForm.patchValue({
      name: this.product.name,
      
    });
  }  


  deleteProduct(): void {
    if (this.product.id == '0') {
      this.onSaveComplete();
    } else {
      if (confirm(`Are you sure want to delete this Product: ${this.product.name}?`)) {
        this.productService.deleteProduct(this.product.id)
          .subscribe(
            () => this.onSaveComplete(),
            (error: any) => this.errorMessage = <any>error
          );
      }
    }
  } 


  saveProduct(): void {  
    if (this.productForm.valid) {  
      if (this.productForm.dirty) {
        const p = { ...this.product, ...this.productForm.value };
        console.log(p)
        if (p.id === '0') {
          this.productService.createProduct(p)  
            .subscribe(  
              () => this.onSaveComplete(),  
              (error: any) => this.errorMessage = <any>error  
            );  
        } else {
          this.productService.updateProduct(p)  
            .subscribe(  
              () => this.onSaveComplete(),  
              (error: any) => this.errorMessage = <any>error  
            );  
        }  
      } else {  
        this.onSaveComplete();  
      }  
    } else {  
      this.errorMessage = 'Please correct the validation errors.';  
    }  
  }  

  ngOnDestroy(): void {
    this.sub.unsubscribe();  
  }


  onSaveComplete(): void {
    this.productForm.reset();
    this.router.navigate(['/products']);
  }
}
