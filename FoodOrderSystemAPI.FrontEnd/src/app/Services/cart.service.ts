import { Injectable } from '@angular/core';
import { FullProductDto } from '../_models/product/FullProductDto';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  constructor() {}
  addToCart(newProduct: FullProductDto) {
    let cartList: FullProductDto[] = [];
    let cartListString = localStorage.getItem('cartList');
    if (cartListString !== null) {
      cartList = JSON.parse(cartListString);
    }
    cartList.push(newProduct);
    console.log(cartList);
    localStorage.setItem('cartList', JSON.stringify(cartList));
  }

  removeFromCart(productToRemove: FullProductDto) {
    let cartList: FullProductDto[] = [];
    let cartListString = localStorage.getItem('cartList');
    if (cartListString !== null) {
      cartList = JSON.parse(cartListString);
    }
    for (let index = 0; index < cartList.length; index++) {
      if (cartList[index].ProductID == productToRemove.ProductID) {
        cartList.splice(index, 1);
        break;
      }
    }
  }

  getCart(): FullProductDto[] {
    let cartList: FullProductDto[] = [];
    let cartListString = localStorage.getItem('cartList');
    if (cartListString !== null) {
      cartList = JSON.parse(cartListString);
    }
    return cartList;
  }
}
