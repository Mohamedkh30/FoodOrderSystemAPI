import { Component } from '@angular/core';
import { FullProductCardDto } from 'src/app/_models/product/FullProductCardDto';
import { RestaurantDto } from 'src/app/_models/restaurant/RestaurantDto';

@Component({
  selector: 'app-restaurant-details',
  templateUrl: './restaurant-details.component.html',
  styleUrls: ['./restaurant-details.component.css']
})
export class RestaurantDetailsComponent {
  filterCategories:string[] = ["pasta","seafood","burger","pizza","vegetrian"].sort()
  searchString:string = "";

  productsList:FullProductCardDto[]|null = [];

  

  search(){
    console.log(this.searchString)
  }
}
