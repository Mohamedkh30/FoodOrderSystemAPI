import { Injectable } from '@angular/core';
import { ConfigService } from './config.service';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { RestaurantDetailsDto } from '../types/Restaurant/Restaurants-Read-dto';
import { RestaurantProductsDto } from '../types/Restaurant/Restaurant-Products-dto';
import { RestaurantDetailsByIdDto } from '../types/Restaurant/Restaurant-Details-By-Id-dto';

@Injectable({
    providedIn: 'root',
})
export class RestaurantService {
    constructor(private configService: ConfigService, private http: HttpClient) {}

    getAllRestaurants(): Observable<RestaurantDetailsDto[]> {
        let baseUrl: string = this.configService.getBaseApiUrl();
        // console.log(`${baseUrl}Restaurant`);
        return this.http.get<RestaurantDetailsDto[]>(`${baseUrl}Restaurant`);
    }

    getRestaurantDetailsById(RestaurantId: number): Observable<RestaurantDetailsByIdDto> {
        let baseUrl: string = this.configService.getBaseApiUrl();
        console.log(`${baseUrl}Restaurant/Products/${RestaurantId}`);
        return this.http.get<RestaurantDetailsByIdDto>(`${baseUrl}Restaurant/Products/${RestaurantId}`);
    }

    getRestaurantProducts(RestaurantId: number): Observable<RestaurantProductsDto> {
        let baseUrl: string = this.configService.getBaseApiUrl();
        // console.log(`${baseUrl}Restaurant/Products/${RestaurantId}`);
        return this.http.get<RestaurantProductsDto>(`${baseUrl}Restaurant/${RestaurantId}`);
    }
}