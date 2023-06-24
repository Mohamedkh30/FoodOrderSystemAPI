import { Component, Input } from '@angular/core';
import { FullProductDto } from 'src/app/_models/product/FullProductDto';
import { ProductCardDto } from 'src/app/types/Product/Product-Card-dto';
import { RestaurantDto } from 'src/app/_models/restaurant/RestaurantDto';
import { RestaurantApiTestComponent } from '../restaurant-api-test/restaurant-api-test.component';

@Component({
  selector: 'app-rest-card',
  templateUrl: './rest-card.component.html',
  styleUrls: ['./rest-card.component.css']
})
export class RestCardComponent {
  @Input() product:ProductCardDto = new ProductCardDto(
    0,"Flafel",10,"flafel so5na","https://www.holidaysmart.com/sites/default/files/daily/2020/falafel-shs_1500.jpg",0.45555,4,["vegetrian"], 1, "KFC"
  );


  getRestaurantDetailsById(): void {
    
  }

    addToCart(){
      let cartListString = localStorage.getItem('cartList');

      if(cartListString === null){
        let cartList:ProductCardDto[] = [];
        cartList.push(this.product)
        console.log(cartList);
        localStorage.setItem('cartList',JSON.stringify(cartList));
      }else{
        let cartList:ProductCardDto[] = JSON.parse(cartListString);
        cartList.push(this.product)
        console.log(cartList);
        localStorage.setItem('cartList',JSON.stringify(cartList));
      }
    }
}
