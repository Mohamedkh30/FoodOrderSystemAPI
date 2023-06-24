import { Injectable } from '@angular/core';
import { ConfigService } from './config.service';
import { FullProduct } from '../types/Product/full-product-dto';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ProductAdd } from '../types/Product/product-add';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  productToAdd: ProductAdd = new ProductAdd();

  constructor(private configService: ConfigService, private http: HttpClient) {}
  
  getProduct(productId: number): Observable<FullProduct> {
    let baseUrl: string = this.configService.getBaseApiUrl();
    return this.http.get<FullProduct>(`${baseUrl}products/${productId}`);
  }
  AddProduct(): Observable<number> {
    let baseUrl: string = this.configService.getBaseApiUrl();
    return this.http.post<number>(`${baseUrl}products` , this.productToAdd);
  }
}
