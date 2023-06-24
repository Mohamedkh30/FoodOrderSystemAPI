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
    if(cat.length==0)
      return this.http.get<FullProductCardDto[]>(`${baseUrl}Products`)	
    else
		  return this.http.get<FullProductCardDto[]>(`${baseUrl}Products/FilterTags?${cat.map((value) => `FilterTags=${value}`).join('&')}`)		
  }

  getAllResaurantFiltered(cat:string[]){
    let baseUrl: string = this.configService.getBaseApiUrl();
    if(cat.length==0)
      return this.http.get<FullProductCardDto[]>(`${baseUrl}Products`)	
    else
		  return this.http.get<FullProductCardDto[]>(`${baseUrl}Products/FilterRestaurants?${cat.map((value) => `FilterRestaurants=${value}`).join('&')}`)		
  }

  getAllPricesFiltered(cat:Number[]){
    let baseUrl: string = this.configService.getBaseApiUrl();
    if(cat.length==0)
      return this.http.get<FullProductCardDto[]>(`${baseUrl}Products`)	
    else
		  return this.http.get<FullProductCardDto[]>(`${baseUrl}Products/FilterPrices?${cat.map((value) => `FilterPrices=${value}`).join('&')}`)		
  }

  searchProductByName(searchString:string){
    let baseUrl: string = this.configService.getBaseApiUrl();
    if(searchString.length==0)
      return this.http.get<FullProductCardDto[]>(`${baseUrl}Products`)	
    else
		  return this.http.get<FullProductCardDto[]>(`${baseUrl}Products/searchProduct?query=${searchString}`)		
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
