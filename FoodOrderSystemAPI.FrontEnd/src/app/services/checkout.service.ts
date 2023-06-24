import { Injectable } from '@angular/core';
import { CheckoutComponent } from '../checkout/checkout.component';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
  })

  export class CheckoutService {


    baseurl:string="https://localhost:7020/api/orders/"

    getAll() {
        return this.http.get<CheckoutComponent[]>(this.baseurl);
       }
     

     
       getOrder(id:number){
     
         return this.http.get<CheckoutComponent>(this.baseurl+id)
         // return null;
       }
       updateOrder(crs:CheckoutComponent) {
        
       }
     
       deleteOrder(id:number) {
         return this.http.delete(this.baseurl+id);
       }
     



    // submitForm(formData: any) {
    //     // Make an HTTP POST request to your API endpoint
    //     return this.http.post(this.baseurl, CheckoutComponent);
    //   }






    constructor(public http:HttpClient) {}
  }









