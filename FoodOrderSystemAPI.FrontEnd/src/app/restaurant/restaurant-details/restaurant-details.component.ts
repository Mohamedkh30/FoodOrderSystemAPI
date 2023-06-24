import { Component, OnInit } from '@angular/core';
import { RestaurantService } from 'src/app/services/restaurant.service';
import { RestaurantDetailsByIdDto } from 'src/app/types/Restaurant/Restaurant-Details-By-Id-dto';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-restaurant-details',
  templateUrl: './restaurant-details.component.html',
  styleUrls: ['./restaurant-details.component.css']
})
export class RestaurantDetailsComponent implements OnInit {
  restaurantDetails: RestaurantDetailsByIdDto | null = null;
  searchString:string = "";
  constructor(private restaurantService: RestaurantService, private activatedRoute: ActivatedRoute) {}

  ngOnInit(): void {
    this.getRestaurantDetailsById();
  }

  getRestaurantDetailsById(): void {
    let urlRestaurantId = this.activatedRoute.snapshot.paramMap.get('id');
    if (urlRestaurantId) {
      let restaurantId = parseInt(urlRestaurantId);
      console.log(restaurantId);
      this.restaurantService.getRestaurantDetailsById(restaurantId)
      .subscribe((restaurantDetails: RestaurantDetailsByIdDto | null) => {
        if (restaurantDetails) {
          this.restaurantDetails = restaurantDetails;
          console.log(restaurantDetails);
      } else {
        console.log('Restaurant not found');
      }
    },
      (error) => {
        console.log('Error occurred while retrieving restaurant details:', error);
      }
    );
      
    }
  }

  /*
  getRestaurantDetails(id: number): void {
  this.restaurantService.getRestaurantDetailsById(id)
    .subscribe(
      (restaurantDetails: RestaurantDetailsDto | null) => {
        if (restaurantDetails) {
          // Use the retrieved restaurant details
          console.log(restaurantDetails);
        } else {
          // Restaurant details not found
          console.log('Restaurant not found');
        }
      },
      (error) => {
        console.log('Error occurred while retrieving restaurant details:', error);
      }
    );
}
  */

  search(){
    console.log(this.searchString)
  }
}