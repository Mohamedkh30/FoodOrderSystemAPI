import { Component } from '@angular/core';

@Component({
  selector: 'app-resturant-orders',
  templateUrl: './resturant-orders.component.html',
  styleUrls: ['./resturant-orders.component.css']
})
export class ResturantOrdersComponent {
  isComponentVisible = false;

  toggleComponentVisibility() {
    console.log(this.isComponentVisible)
    this.isComponentVisible = !this.isComponentVisible;
  }  
}
