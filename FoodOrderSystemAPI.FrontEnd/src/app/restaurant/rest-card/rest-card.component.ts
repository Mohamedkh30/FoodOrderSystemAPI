import { Component, Input } from '@angular/core';
import { FullProductDto } from 'src/app/_models/product/FullProductDto';
import { RestaurantDto } from 'src/app/_models/restaurant/RestaurantDto';

@Component({
  selector: 'app-rest-card',
  templateUrl: './rest-card.component.html',
  styleUrls: ['./rest-card.component.css']
})
export class RestCardComponent {
  @Input() product:FullProductDto = new FullProductDto(
    0,"Flafel",10,"flafel so5na","https://www.holidaysmart.com/sites/default/files/daily/2020/falafel-shs_1500.jpg",0.45555,4,"vegetrian",new RestaurantDto(0,"KFC")
  );

    

    addToCart(){
      let cartListString = localStorage.getItem('cartList');

      if(cartListString === null){
        let cartList:FullProductDto[] = [];
        cartList.push(this.product)
        console.log(cartList);
        localStorage.setItem('cartList',JSON.stringify(cartList));
      }else{
        let cartList:FullProductDto[] = JSON.parse(cartListString);
        cartList.push(this.product)
        console.log(cartList);
        localStorage.setItem('cartList',JSON.stringify(cartList));
      }
    }
}
