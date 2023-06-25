import { Component, OnInit } from '@angular/core';
import { AuthentcationService } from 'src/app/services/authentcation.service';
import { RestaurantService } from 'src/app/services/restaurant.service';
import { ResturantOrderDto } from 'src/app/types/Order/resturant-order-dto';
import { ProductOrder } from 'src/app/types/Product/product-order';

@Component({
  selector: 'app-resturant-orders',
  templateUrl: './resturant-orders.component.html',
  styleUrls: ['./resturant-orders.component.css']
})
export class ResturantOrdersComponent implements OnInit {
  isComponentVisible = false;

  ComponentResturantOrders: ResturantOrderDto[] = []; 
  
  OrderProducts: ProductOrder[] = [];

  ngOnInit(): void {
    const ResturnatId = this.AuthenticationService.UserLogin?.id;
    this.Resturantservice.GetResturantOrders(ResturnatId!).subscribe((ResturnatOrders) => {
      console.log(ResturnatOrders);
      console.log(ResturnatId);
      this.ComponentResturantOrders = ResturnatOrders
     })
  }
  constructor(public Resturantservice: RestaurantService ,private AuthenticationService :AuthentcationService) { }
  

  toggleComponentVisibility(OrderProducts : ProductOrder[]) {
    console.log(this.isComponentVisible)
    this.isComponentVisible = !this.isComponentVisible;
    this.OrderProducts = OrderProducts;
  }  
}
