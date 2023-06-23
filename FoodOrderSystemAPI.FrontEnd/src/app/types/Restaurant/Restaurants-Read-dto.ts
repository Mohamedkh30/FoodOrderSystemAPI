export class RestaurantDetailsDto {
    constructor(
        public restaurantName: string = '',
        public address: string = '',
        public logo: string = '',
        public phone: string = '',
        public paymentMethods: PaymentType = PaymentType.Cash
    ) {}
}

export enum PaymentType {
    Cash,
    Credit,
    Both
}
