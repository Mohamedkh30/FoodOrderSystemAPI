import { RestaurantDto } from "../restaurant/RestaurantDto";

export class FullProductDto {
    constructor(
        public ProductID:number = 0,
        public Productname:string = "",
        public price:number = 0,
        public describtion:String  = "",
        public img :String  = "",
        public offer:number = 0 ,
        public rate:number = 0 ,
        public type:String = "",
        public RestaurantModel:RestaurantDto
    ){

    }
}
