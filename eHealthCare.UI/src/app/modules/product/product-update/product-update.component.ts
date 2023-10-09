import { Component, ElementRef, OnDestroy, OnInit, ViewChildren } from '@angular/core';
import { FormControlName, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ActiveIngredient } from '../../../model/active-ingredient';
import { ATCCode } from '../../../model/atccode';
import { PharmaceuticalForm } from '../../../model/pharmaceutical-form';
import { ProductUnit } from '../../../model/product-unit';
import { TherapeuticClass } from '../../../model/therapeutic-class';
import { ProductRelatedModelsService } from '../../../service/product-related-models.service';
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
  ProductUnit: ProductUnit[] = [];
  PharmaceuticalForm: PharmaceuticalForm[] = [];
  ActiveIngredient: ActiveIngredient[] = [];
  TherapeuticClass: TherapeuticClass[] = [];
  ATCCode: ATCCode[] = [];
  private sub!: Subscription;

  displayMessage: { [key: string]: string } = {};
  private validationMessages: { [key: string]: { [key: string]: string } };  

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private productService: ProductService,
    private productRelatedModelService: ProductRelatedModelsService) {

    this.getActiveIngredientData();
    this.getPharmaceuticalFormData();
    this.getProductUnitData();
    this.getTherapeuticClassData();
    this.getATCCodeData();

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
      activeIngredientId: 0,
      pharmaceuticalFormId: 0,
      productUnitId: 0,
      atcCodeId: 0,
      therapeuticClassId: 0 
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
            activeIngredient: '',
            pharmaceuticalForm: '',
            therapeuticClass: '',
            atcCode: '',
            activeIngredientId: 0,
            pharmaceuticalFormId: 0,
            productUnitId: 0,
            productUnit: '',
            atcCodeId: 0,
            therapeuticClassId: 0 
          };
          this.displayProduct(product);
        }
        else {
          this.getProduct(id!);
        }
      }
    );  
  }


  getPharmaceuticalFormData() {
    this.productRelatedModelService.getPharmaceuticalForms().subscribe(
      data => {
        console.log(data)
        this.PharmaceuticalForm = data;
      },
      error => this.errorMessage = <any>error
    );
  }

  getProductUnitData() {
    this.productRelatedModelService.getProductUnits().subscribe(
      data => {
        console.log(data)
        this.ProductUnit = data;
      },
      error => this.errorMessage = <any>error
    );
  }

  getActiveIngredientData() {
    this.productRelatedModelService.getActiveIngredients().subscribe(
      data => {
        console.log(data)
        this.ActiveIngredient = data;
      },
      error => this.errorMessage = <any>error
    );
  }

  getTherapeuticClassData() {
    this.productRelatedModelService.getTherapeuticClass().subscribe(
      data => {
        console.log(data)
        this.TherapeuticClass = data;
      },
      error => this.errorMessage = <any>error
    );
  }

  getATCCodeData() {
    this.productRelatedModelService.getATCCodes().subscribe(
      data => {
        console.log(data)
        this.ATCCode = data;
      },
      error => this.errorMessage = <any>error
    );
  }

  getProduct(id: string): void {
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
      classifications: this.product.classifications,
      competentAuthorityStatus: this.product.competentAuthorityStatus,
      internalStatus: this.product.internalStatus,
      unit: this.product.productUnit,
      activeIngredient: '',
      pharmaceuticalForm: '',
      therapeuticClass: this.product.therapeuticClass,
      atcCode: this.product.atcCode,
      activeIngredientId: this.product.activeIngredientId,
      pharmaceuticalFormId: this.product.pharmaceuticalFormId,
      productUnitId: this.product.productUnitId,
      productUnit: this.product.productUnit,
      atcCodeId: this.product.atcCodeId,
      therapeuticClassId: this.product.therapeuticClassId
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
