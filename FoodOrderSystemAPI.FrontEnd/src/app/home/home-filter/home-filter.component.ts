import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-home-filter',
  templateUrl: './home-filter.component.html',
  styleUrls: ['./home-filter.component.css']
})
export class HomeFilterComponent {
  @Input() Categories:string[] = [];
  @Input() Restaurants:string[] = [];

  rangeValues:number[] = [0,0];
  
  selectedRestaurants:string[] = [];
  selectedCategories:string[] = [];

  updateSlider(){
    this.rangeValues[0]=this.rangeValues[0]*5;
    this.rangeValues[1]=this.rangeValues[1]*5;
  }

}
