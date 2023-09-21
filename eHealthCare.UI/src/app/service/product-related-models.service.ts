import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, of } from 'rxjs';
import { environment } from '../../environments/environment';
import { ActiveIngredient } from '../model/active-ingredient';
import { ATCCode } from '../model/atccode';
import { PharmaceuticalForm } from '../model/pharmaceutical-form';
import { ProductUnit } from '../model/product-unit';
import { TherapeuticClass } from '../model/therapeutic-class';

@Injectable({
  providedIn: 'root'
})
export class ProductRelatedModelsService {
  private ActiveIngredientUrl = environment.baseUrl + "api/ActiveIngredients";
  private ATCCodestUrl = environment.baseUrl + "api/ATCCodes";
  private PharmaceuticalFormsUrl = environment.baseUrl + "api/PharmaceuticalForms";
  private ProductUnitsUrl = environment.baseUrl + "api/ProductUnits";
  private TherapeuticClassUrl = environment.baseUrl + "api/TherapeuticClass";


  constructor(private http: HttpClient) { }

  getActiveIngredients(): Observable<ActiveIngredient[]> {
    return this.http.get<ActiveIngredient[]>(this.ActiveIngredientUrl)
      .pipe(
        catchError(this.handleError<ActiveIngredient[]>('getActiveIngredients'))
      );
  }

  getATCCodes(): Observable<ATCCode[]> {
    return this.http.get<ATCCode[]>(this.ATCCodestUrl)
      .pipe(
        catchError(this.handleError<ATCCode[]>('getATCCodes'))
      );
  }

  getPharmaceuticalForms(): Observable<PharmaceuticalForm[]> {
    return this.http.get<PharmaceuticalForm[]>(this.PharmaceuticalFormsUrl)
      .pipe(
        catchError(this.handleError<PharmaceuticalForm[]>('getPharmaceuticalForms'))
      );
  }

  getProductUnits(): Observable<ProductUnit[]> {
    return this.http.get<ProductUnit[]>(this.ProductUnitsUrl)
      .pipe(
        catchError(this.handleError<ProductUnit[]>('getProductUnits'))
      );
  }

  getTherapeuticClass(): Observable<TherapeuticClass[]> {
    return this.http.get<TherapeuticClass[]>(this.TherapeuticClassUrl)
      .pipe(
        catchError(this.handleError<TherapeuticClass[]>('getTherapeuticClass'))
      );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error); // Log the error to the console
      return of(result as T); // Return an empty result to keep the app running
    };
  }
}
