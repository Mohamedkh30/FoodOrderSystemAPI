import { Component, OnInit } from '@angular/core';
import { RestaurantService } from 'src/app/services/restaurant.service';
import { RestaurantDetailsDto } from 'src/app/types/Restaurant/Restaurants-Read-dto';
import { RestaurantProductsDto } from 'src/app/types/Restaurant/Restaurant-Products-dto';

@Component({
  selector: 'app-restaurant-api-test',
  templateUrl: './restaurant-api-test.component.html',
  styleUrls: ['./restaurant-api-test.component.css']
})
export class RestaurantApiTestComponent implements OnInit {
  restaurants: RestaurantDetailsDto[] = [];
  restaurantProducts: RestaurantProductsDto | undefined;

  constructor(private restaurantService: RestaurantService) {}

  ngOnInit() {
    // this.getAllRestaurants();
    // console.log(this.restaurants);
    // this.getRestaurantProducts();
    // console.log(this.restaurantProducts);
  }

  getAllRestaurants(): void {
    this.restaurantService.getAllRestaurants()
      .subscribe(restaurants => this.restaurants = restaurants);
  }

  getRestaurantProducts(): void {
    this.restaurantService.getRestaurantProducts(1)
      .subscribe(data => this.restaurantProducts = data);
  }


}
