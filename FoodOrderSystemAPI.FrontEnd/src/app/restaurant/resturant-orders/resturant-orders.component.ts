import { Component, OnInit } from '@angular/core';
import { AuthentcationService } from 'src/app/services/authentcation.service';
import { RestaurantService } from 'src/app/services/restaurant.service';
import { ResturantOrderDto } from 'src/app/types/Order/resturant-order-dto';
import { ProductOrder } from 'src/app/types/Product/product-order';
// import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-resturant-orders',
  templateUrl: './resturant-orders.component.html',
  styleUrls: ['./resturant-orders.component.css']
})
export class ResturantOrdersComponent implements OnInit {
  isComponentVisible = false;

  

  ComponentResturantOrders: ResturantOrderDto[] = []; 
  
  OrderProducts: ProductOrder[] = [];

  OrderTotalPrice: Number = 0;

  ngOnInit(): void {
    const RestaurantId = this.AuthenticationService.UserLogin?.id;
    console.log(RestaurantId)
    this.Resturantservice.GetResturantOrders(8).subscribe((ResturnatOrders) => {
      console.log(ResturnatOrders);
      console.log(RestaurantId);
      this.ComponentResturantOrders = ResturnatOrders
     })
  }
  constructor(public Resturantservice: RestaurantService ,private AuthenticationService :AuthentcationService ) { }
  

  toggleComponentVisibility(OrderProducts : ProductOrder[] = [] , TotalPrice :Number = 0) {
    console.log(this.isComponentVisible)
    this.isComponentVisible = !this.isComponentVisible;
    this.OrderProducts = OrderProducts;
    this.OrderTotalPrice = TotalPrice;
  }  
}
