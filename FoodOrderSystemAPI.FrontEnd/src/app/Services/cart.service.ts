import { Injectable } from '@angular/core';
import { CartItem } from '../_models/cartItem/CartItem';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  private _localStorageCartName: string = 'Cart';
  constructor() {}
  addToCart(newCartItem: CartItem) {
    let cartItems: CartItem[] = [];
    let cartItemsString = localStorage.getItem(this._localStorageCartName);
    if (cartItemsString !== null) {
      cartItems = JSON.parse(cartItemsString);
    }
    cartItems.push(newCartItem);
    localStorage.setItem(this._localStorageCartName, JSON.stringify(cartItems));
  }

  removeFromCart(cartItemToRemove: CartItem) {
    let cartItems: CartItem[] = [];
    let cartItemsString = localStorage.getItem(this._localStorageCartName);
    if (cartItemsString !== null) {
      cartItems = JSON.parse(cartItemsString);
    }
    for (let index = 0; index < cartItems.length; index++) {
      const element = cartItems[index];
      if (
        cartItems[index].product.productID == cartItemToRemove.product.productID
      ) {
        cartItems.splice(index, 1);
        break;
      }
    }
    localStorage.setItem(this._localStorageCartName, JSON.stringify(cartItems));
  }

  getCart(): CartItem[] {
    let cartItems: CartItem[] = [];
    let cartItemsString = localStorage.getItem(this._localStorageCartName);
    if (cartItemsString !== null) {
      cartItems = JSON.parse(cartItemsString);
    }
    return cartItems;
  }
}
