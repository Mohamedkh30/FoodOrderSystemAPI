import { RestaurantDetailsDto } from "../Restaurant/Restaurants-Read-dto";

export class FullProduct {
  constructor(
    public productID: number = 0,
    public productname: string = '',
    public price: number = 0,
    public describtion: string = '',
    public img: string = '',
    public offer: number = 0,
    public rate: number = 0,
    public type: string = '',
    public restaurant: RestaurantDetailsDto = new RestaurantDetailsDto(0)
  ) {}
}