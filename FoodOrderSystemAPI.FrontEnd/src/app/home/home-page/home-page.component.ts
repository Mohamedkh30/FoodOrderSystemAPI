import { Component } from '@angular/core';
import { FullProductDto } from 'src/app/_models/product/FullProductDto';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent {
  filterCategories:string[] = ["pasta","seafood","burger","pizza","vegetrian"].sort()
  filterRestaurants:string[] = ["KFC","Baraka","sultan ayoub"].sort()
  searchString:string = "";

  productsList:FullProductDto[]|null = null;

  search(){
    console.log(this.searchString)
  }
}
