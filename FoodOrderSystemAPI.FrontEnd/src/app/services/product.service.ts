import { Injectable } from '@angular/core';
import { ConfigService } from './config.service';
import { FullProduct } from '../types/Product/full-product-dto';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { FullProductCardDto } from '../_models/product/FullProductCardDto';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  constructor(private configService: ConfigService, private http: HttpClient) {}

  getProduct(productId: number): Observable<FullProduct> {
    let baseUrl: string = this.configService.getBaseApiUrl();
    return this.http.get<FullProduct>(`${baseUrl}Products/${productId}`);
  }

  getAll(){
    let baseUrl: string = this.configService.getBaseApiUrl();
		return this.http.get<FullProductCardDto[]>(`${baseUrl}Products`)		
	}

  getAllCategoryFiltered(cat:string[]){
    let baseUrl: string = this.configService.getBaseApiUrl();
    console.log(`${baseUrl}Products/FilterTags?${cat.map((value) => encodeURIComponent(value)).join('&')}`)
		return this.http.get<FullProductCardDto[]>(`${baseUrl}Products/FilterTags?${cat.map((value) => encodeURIComponent(value)).join('&')}`)		
	}

  getAllTags(){
    let baseUrl: string = this.configService.getBaseApiUrl();
		return this.http.get<string[]>(`${baseUrl}Products/Tags`)		
	}

  getPriceBounds(){
    let baseUrl: string = this.configService.getBaseApiUrl();
		return this.http.get<number[]>(`${baseUrl}Products/PriceBounds`)
  }


}
