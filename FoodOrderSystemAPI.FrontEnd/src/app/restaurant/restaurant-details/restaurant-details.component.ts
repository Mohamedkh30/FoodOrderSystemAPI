import { Component, OnInit } from '@angular/core';
import { FullProductCardDto } from 'src/app/_models/product/FullProductCardDto';
import { RestaurantDto } from 'src/app/_models/restaurant/RestaurantDto';
import { RestaurantService } from 'src/app/services/restaurant.service';
import { RestaurantDetailsDto } from 'src/app/types/Restaurant/Restaurants-Read-dto';

@Component({
  selector: 'app-restaurant-details',
  templateUrl: './restaurant-details.component.html',
  styleUrls: ['./restaurant-details.component.css']
})
export class RestaurantDetailsComponent implements OnInit {
  
  restaurants: RestaurantDetailsDto[] = [];
  searchString:string = "";
  constructor(private restaurantService: RestaurantService) {}

  ngOnInit(): void {
    this.getAllRestaurants();
  }

  getAllRestaurants(): void {
    this.restaurantService.getAllRestaurants()
      .subscribe(restaurants => this.restaurants = restaurants);
  }
  productsList:FullProductCardDto[]|null = [];

  

  search(){
    console.log(this.searchString)
  }
}