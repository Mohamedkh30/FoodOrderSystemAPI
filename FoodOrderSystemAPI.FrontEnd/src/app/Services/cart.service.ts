import { Injectable } from '@angular/core';
import { CartItem } from '../_models/cartItem/CartItem';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  private _localStorageCartName: string = 'Cart';

  constructor() {}

  //#region  methods
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

  calculateTotalPrice(): number {
    let cartItems: CartItem[] = [];
    let cartItemsString = localStorage.getItem(this._localStorageCartName);
    if (cartItemsString !== null) {
      cartItems = JSON.parse(cartItemsString);
    }
    let totalPrice = 0;
    for (let index = 0; index < cartItems.length; index++) {
      totalPrice += cartItems[index].product.price * cartItems[index].quantity;
    }
    return totalPrice;
  }

  emptyCart(): void {
    localStorage.removeItem(this._localStorageCartName);
  }
  //#endregion
}
