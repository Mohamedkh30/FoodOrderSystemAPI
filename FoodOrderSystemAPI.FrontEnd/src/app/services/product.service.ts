import { Injectable } from '@angular/core';
import { ConfigService } from './config.service';
import { FullProduct } from '../types/Product/full-product-dto';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  constructor(private configService: ConfigService, private http: HttpClient) {}

  getProduct(productId: number): Observable<FullProduct> {
    let baseUrl: string = this.configService.getBaseApiUrl();
    return this.http.get<FullProduct>(`${baseUrl}products/${productId}`);
  }
}
