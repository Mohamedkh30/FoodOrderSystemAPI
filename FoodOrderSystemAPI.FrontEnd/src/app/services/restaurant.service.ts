import { Injectable } from '@angular/core';
import { ConfigService } from './config.service';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { RestaurantDetailsDto } from '../types/Restaurant/Restaurants-Read-dto';

@Injectable({
    providedIn: 'root',
})
export class RestaurantService {
    constructor(private configService: ConfigService, private http: HttpClient) {}

    getAllRestaurants(): Observable<RestaurantDetailsDto[]> {
        let baseUrl: string = this.configService.getBaseApiUrl();
        // console.log(`${baseUrl}/Restaurant`);
        return this.http.get<RestaurantDetailsDto[]>(`${baseUrl}Restaurant`);
    }
}