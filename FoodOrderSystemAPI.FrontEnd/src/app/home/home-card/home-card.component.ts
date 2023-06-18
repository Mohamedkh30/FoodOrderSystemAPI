import { Component } from '@angular/core';
import { FullProductDto } from 'src/app/_models/product/FullProductDto';
import { RestaurantDto } from 'src/app/_models/restaurant/RestaurantDto';

@Component({
  selector: 'app-home-card',
  templateUrl: './home-card.component.html',
  styleUrls: ['./home-card.component.css']
})
export class HomeCardComponent {
    product:FullProductDto = new FullProductDto(
      0,"Flafel",10,"flafel so5na","https://www.holidaysmart.com/sites/default/files/daily/2020/falafel-shs_1500.jpg",0.45555,4,"vegetrian",new RestaurantDto(0,"KFC")
    );

    addToCart(){
      console.log("added")
    }
}
