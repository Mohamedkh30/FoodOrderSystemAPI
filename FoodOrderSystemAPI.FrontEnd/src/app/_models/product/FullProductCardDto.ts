import { RestaurantDto } from "../restaurant/RestaurantDto";

export class FullProductCardDto {
    constructor(
        public productID:number = 0,
        public productname:string = "",
        public price:number = 0,
        public describtion:String  = "",
        public img :String  = "",
        public offer:number = 0 ,
        public rate:number = 0 ,
        public tags:String[] = [],
        public restaurantID:number = 0,
        public restaurantName:string = "",
    ){

    }
}
