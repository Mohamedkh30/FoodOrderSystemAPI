import { Component } from '@angular/core';
import { FullProductCardDto } from 'src/app/_models/product/FullProductCardDto';
import { RestaurantDto } from 'src/app/_models/restaurant/RestaurantDto';

@Component({
  selector: 'app-restaurant-page',
  templateUrl: './restaurant-page.component.html',
  styleUrls: ['./restaurant-page.component.css']
})
export class RestaurantPageComponent {
  filterCategories:string[] = ["pasta","seafood","burger","pizza","vegetrian"].sort()
  searchString:string = "";

  productsList:FullProductCardDto[]|null = [];

  

  search(){
    console.log(this.searchString)
  }
}
