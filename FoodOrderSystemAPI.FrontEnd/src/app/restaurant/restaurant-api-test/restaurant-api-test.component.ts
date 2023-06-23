import { Component, OnInit } from '@angular/core';
import { RestaurantService } from 'src/app/services/restaurant.service'
import { RestaurantDetailsDto } from 'src/app/types/Restaurant/Restaurants-Read-dto'

@Component({
  selector: 'app-restaurant-api-test',
  templateUrl: './restaurant-api-test.component.html',
  styleUrls: ['./restaurant-api-test.component.css']
})
export class RestaurantApiTestComponent implements OnInit {
  restaurants: RestaurantDetailsDto[] = [];

  constructor(private restaurantService: RestaurantService) {}

  ngOnInit() {
    this.getAllRestaurants();
    // console.log(this.restaurants);
    
  }

  getAllRestaurants(): void {
    // console.log('lol');
    
    this.restaurantService.getAllRestaurants()
      .subscribe(restaurants => this.restaurants = restaurants);
  }
}
