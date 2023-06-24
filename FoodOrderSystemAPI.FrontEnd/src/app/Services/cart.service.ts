//#region imports
import { Injectable, OnInit } from '@angular/core';
import { CartItem } from '../_models/cartItem/CartItem';

//#endregion

@Injectable({
  providedIn: 'root',
})
export class CartService implements OnInit {
  //#region  feilds
  private _localStorageCartName: string = 'Cart';

  public CartItems: CartItem[] = [];
  public TotalNumberOfItems: number = 0;
  public TotalPrice: number = 0;
  //#endregion

  constructor() {}

  ngOnInit(): void {
    //#region filling CartItems
    this.CartItems = [];
    let cartItemsString = localStorage.getItem(this._localStorageCartName);
    if (cartItemsString !== null) {
      this.CartItems = JSON.parse(cartItemsString);
    }
    //#endregion

    //#region filling NumberOfItems
    this.TotalNumberOfItems = this.calculateTotalNumberOfItems();
    //#endregion

    //#region filling TotalPrice
    this.TotalPrice = this.calculateTotalPrice();
    //#endregion
  }

  //#region private methods
  private calculateTotalNumberOfItems(): number {
    let count = 0;
    this.CartItems.forEach((item) => {
      count += item.quantity;
    });
    return count;
  }

  //#endregion

  //#region  public methods
  addToCart(newCartItem: CartItem) {
    let cartItems: CartItem[] = [];
    let cartItemsString = localStorage.getItem(this._localStorageCartName);
    if (cartItemsString !== null) {
      cartItems = JSON.parse(cartItemsString);
    }
    cartItems.push(newCartItem);
    localStorage.setItem(this._localStorageCartName, JSON.stringify(cartItems));
    this.CartItems = cartItems;
    this.TotalNumberOfItems += newCartItem.quantity;
    this.TotalPrice += newCartItem.product.price * newCartItem.quantity;
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
    this.CartItems = cartItems;
    this.TotalNumberOfItems -= cartItemToRemove.quantity;
    this.TotalPrice -=
      cartItemToRemove.product.price * cartItemToRemove.quantity;
  }

  getCart(): CartItem[] {
    return this.CartItems;
  }

  calculateTotalPrice(): number {
    let totalPrice = 0;
    for (let index = 0; index < this.CartItems.length; index++) {
      totalPrice +=
        this.CartItems[index].product.price * this.CartItems[index].quantity;
    }
    return totalPrice;
  }

  emptyCart(): void {
    localStorage.removeItem(this._localStorageCartName);
    this.CartItems = [];
  }
  //#endregion
}
