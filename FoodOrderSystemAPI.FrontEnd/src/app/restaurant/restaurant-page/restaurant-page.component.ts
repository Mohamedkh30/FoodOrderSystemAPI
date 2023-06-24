import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FullProductCardDto } from 'src/app/_models/product/FullProductCardDto';
import { RestaurantDto } from 'src/app/_models/restaurant/RestaurantDto';
import { RestaurantService } from 'src/app/services/restaurant.service';
import { RestaurantProductsDto } from 'src/app/types/Restaurant/Restaurant-Products-dto';
import { ProductCardDto } from 'src/app/types/Product/Product-Card-dto';

@Component({
  selector: 'app-restaurant-page',
  templateUrl: './restaurant-page.component.html',
  styleUrls: ['./restaurant-page.component.css']
})
export class RestaurantPageComponent implements OnInit {
  filterCategories:string[] = ["pasta","seafood","burger","pizza","vegetrian"].sort()
  searchString:string = "";
  _products: RestaurantProductsDto = new RestaurantProductsDto();

  constructor(private restaurantService: RestaurantService, private activatedRoute: ActivatedRoute) {}
  productsList:FullProductCardDto[]|null = [];

  ngOnInit(): void {
    this.getRestaurantProducts();
  }

  getRestaurantProducts(): void {
    let urlRestaurantId = this.activatedRoute.snapshot.paramMap.get('id');
    if (urlRestaurantId) {
      let restaurantId = parseInt(urlRestaurantId);
      this.restaurantService.getRestaurantProducts(restaurantId)
        .subscribe(data => this._products = data, error => {
          console.log(`error: ${error}`);
        });
    }
      // console.log(this._products);
  }

  search(){
    console.log(this.searchString)
  }
}
