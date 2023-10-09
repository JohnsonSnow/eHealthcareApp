import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Product } from './product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private productUrl = environment.baseUrl + 'api/products';
  constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.productUrl)
      .pipe(
        catchError(this.handleError<Product[]>('getProducts'))
      );
  }

  getProduct(id: string): Observable<Product> {
    if (id === '') {
      return of(this.initializeProduct());
    }
    const url = `${this.productUrl}/${id}`;
    return this.http.get<Product>(url)
      .pipe(
        catchError(this.handleError<Product>('getProduct'))
      );
  }

  createProduct(product: Product): Observable<Product> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<Product>(this.productUrl, product, { headers: headers })
      .pipe(
        catchError(this.handleError<Product>('createProduct'))
      );
  }

  deleteProduct(id: string): Observable<{}> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.productUrl}/${id}`;
    return this.http.delete<Product>(url, { headers: headers })
      .pipe(
        catchError(this.handleError<Product>('deleteProduct'))
      );
  }

  updateProduct(product: Product): Observable<Product> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.productUrl}/${product.id}`;
    return this.http.put<Product>(url, product, { headers: headers })
      .pipe(
        catchError(this.handleError<Product>('updateProduct'))
      );
  } 

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error); // Log the error to the console
      return of(result as T); // Return an empty result to keep the app running
    };
  }


  private initializeProduct(): Product {
    return {
      id: '',
      name: '',
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
    }
  }
}
