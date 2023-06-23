import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-restaurant-filter',
  templateUrl: './restaurant-filter.component.html',
  styleUrls: ['./restaurant-filter.component.css']
})
export class RestaurantFilterComponent {
  @Input() Categories:string[] = [];

  rangeValues:number[] = [0,0];

  selectedRestaurants:string[] = [];
  selectedCategories:string[] = [];

  updateSlider(){
    this.rangeValues[0]=this.rangeValues[0]*5;
    this.rangeValues[1]=this.rangeValues[1]*5;
  }
}
