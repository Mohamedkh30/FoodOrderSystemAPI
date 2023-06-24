import { Component, Input } from '@angular/core';
import { FullProductCardDto } from 'src/app/_models/product/FullProductCardDto';
import { RestaurantDto } from 'src/app/_models/restaurant/RestaurantDto';

@Component({
  selector: 'app-home-card',
  templateUrl: './home-card.component.html',
  styleUrls: ['./home-card.component.css']
})
export class HomeCardComponent {
  @Input() product:FullProductCardDto = new FullProductCardDto(
    0,"",10,"","https://www.pngkey.com/png/detail/233-2332677_image-500580-placeholder-transparent.png",0,0,[],0,""
  );

    

    addToCart(){
      
      let cartListString = localStorage.getItem('cartList');

      if(cartListString === null){
        let cartList:FullProductCardDto[] = [];
        cartList.push(this.product)
        console.log(cartList);
        localStorage.setItem('cartList',JSON.stringify(cartList));
      }else{
        let cartList:FullProductCardDto[] = JSON.parse(cartListString);
        cartList.push(this.product)
        console.log(cartList);
        localStorage.setItem('cartList',JSON.stringify(cartList));
      }
    }
}
