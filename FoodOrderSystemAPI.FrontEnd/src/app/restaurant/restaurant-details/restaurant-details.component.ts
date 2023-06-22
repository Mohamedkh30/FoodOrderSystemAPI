import { Component } from '@angular/core';
import { FullProductDto } from 'src/app/_models/product/FullProductDto';
import { RestaurantDto } from 'src/app/_models/restaurant/RestaurantDto';

@Component({
  selector: 'app-restaurant-details',
  templateUrl: './restaurant-details.component.html',
  styleUrls: ['./restaurant-details.component.css']
})
export class RestaurantDetailsComponent {
  filterCategories:string[] = ["pasta","seafood","burger","pizza","vegetrian"].sort()
  searchString:string = "";

  productsList:FullProductDto[]|null = [
    new FullProductDto(
      0,"Flafel",3,"flafel so5na","https://www.holidaysmart.com/sites/default/files/daily/2020/falafel-shs_1500.jpg",0.45555,4,"vegetrian",new RestaurantDto(0,"KFC")
    ),
    new FullProductDto(
      1,"fool",5,"flafel so5na","https://kitchen.sayidaty.net/uploads/small/42/423203a50a85745ee5ff98ff201043f7_w750_h500.jpg",0,4,"vegetrian",new RestaurantDto(0,"KFC")
    ),
    new FullProductDto(
      3,"Koshary",20,"flafel so5na","https://i.pinimg.com/originals/4c/37/99/4c37995da59d3e4cdf0da7c57084e2f5.jpg",0.5,4,"vegetrian",new RestaurantDto(0,"KFC")
    ),
    new FullProductDto(
      2,"kebda",30,"flafel so5na","https://egy-news.net/im0photos/20220919/T16635700676390e53d7bc4b1cbbd92af455195f691image.jpg&w=1200&h=675&img.jpg",0.1,4,"sandwitch",new RestaurantDto(0,"KFC")
    ),
  ];

  

  search(){
    console.log(this.searchString)
  }
}
