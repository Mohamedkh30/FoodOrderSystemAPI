import { Component,OnDestroy,OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { FullProductCardDto } from 'src/app/_models/product/FullProductCardDto';
import { RestaurantDto } from 'src/app/_models/restaurant/RestaurantDto';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit ,OnDestroy{

  productsSub:Subscription|null = null;
  categoriesSub:Subscription|null = null;

  filterCategories:string[] = []
  filterRestaurants:string[] = ["KFC","Baraka","sultan ayoub"].sort()
  searchString:string = "";

  constructor(private productService:ProductService){}

  productsList:FullProductCardDto[] = [];

  ngOnInit(): void {
    this.productsSub=this.productService.getAll().subscribe(
      (data) => {
        this.productsList = data;
      },
      (error) => {
        console.log(`error: ${error}`);
      }
    );
      //-------------
    this.categoriesSub=this.productService.getAllTags().subscribe(
      (data) => {
      this.filterCategories = data.sort();
    },
    (error) => {
      console.log(`error: ${error}`);
    }
  );
  }

  ngOnDestroy(): void {
    this.productsSub?.unsubscribe();
    this.categoriesSub?.unsubscribe();
  }

  search(){
    console.log(this.searchString)
  }

  // filterByCategory(){
  //   this.productsSub=this.productService.getAllCategoryFiltered(["local"]).subscribe(
  //     (data) => {
  //       this.productsList = data;
  //     },
  //     (error) => {
  //       console.log(`error: ${error}`);
  //     }
  //   );
  // }
}
