import { Component, Input, OnInit,OnDestroy, Output, EventEmitter } from '@angular/core';
import { Subscription } from 'rxjs';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-home-filter',
  templateUrl: './home-filter.component.html',
  styleUrls: ['./home-filter.component.css']
})
export class HomeFilterComponent {

  constructor(private productService:ProductService){}

  @Input() Categories:string[] = [];
  @Input() Restaurants:string[] = [];

  @Output() filterByCategoryEvent:EventEmitter<string[]> = new EventEmitter<string[]>();
  @Output() filterByRestaurantEvent:EventEmitter<string[]> = new EventEmitter<string[]>();
  @Output() filterByPriceEvent:EventEmitter<Number[]> = new EventEmitter<Number[]>();



  boundSub:Subscription|null=null;
  BoundValues:number[] = [0,0];

  rangeValues:number[] = [0,0];


  selectedRestaurants:string[] = [];
  selectedCategories:string[] = [];

  updateSlider(){
    this.rangeValues[0]=this.rangeValues[0]*this.BoundValues[1]/100;
    this.rangeValues[1]=this.rangeValues[1]*this.BoundValues[1]/100;
  }

  ngOnInit(): void {
    this.boundSub=this.productService.getPriceBounds().subscribe(
      (data) => {
        this.BoundValues = data;
      },
      (error) => {
        console.log(`error: ${error}`);
      }
    );
      
  }

  ngOnDestroy(): void {
    this.boundSub?.unsubscribe();
  }

    filterByCategory()
  {
    this.filterByCategoryEvent.emit(this.selectedCategories);  
  }

  filterByRestaurant()
  {
    this.filterByRestaurantEvent.emit(this.selectedRestaurants);  
  }

  filterByPrice()
  {
    this.filterByPriceEvent.emit(this.rangeValues);  
  }

  
}
