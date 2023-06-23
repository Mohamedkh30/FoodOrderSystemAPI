export class FullProduct {
  productID: number;
  productname: string;
  price: number;
  describtion: string;
  img: string;
  offer: number;
  rate: number;
  type: string;
  restaurant: {
    emailConfirmed: boolean;
    passwordHash: string;
    securityStamp: string;
    concurrencyStamp: string;
    phoneNumber: string;
    phoneNumberConfirmed: boolean;
    twoFactorEnabled: boolean;
    lockoutEnd: string;
    lockoutEnabled: boolean;
    accessFailedCount: number;
    id: number;
    normalizedUserName: string;
    userName: string;
    normalizedEmail: string;
    email: string;
    role: number;
    restaurantName: string;
    address: string;
    logo: string;
    phone: number;
    paymentDetails: string;
  };

  constructor() {
    this.productID = 0;
    this.productname = '';
    this.price = 0;
    this.describtion = '';
    this.img = '';
    this.offer = 0;
    this.rate = 0;
    this.type = '';
    this.restaurant = {
      emailConfirmed: true,
      passwordHash: '',
      securityStamp: '',
      concurrencyStamp: '',
      phoneNumber: '',
      phoneNumberConfirmed: true,
      twoFactorEnabled: true,
      lockoutEnd: '',
      lockoutEnabled: true,
      accessFailedCount: 0,
      id: 0,
      normalizedUserName: '',
      userName: '',
      normalizedEmail: '',
      email: '',
      role: 0,
      restaurantName: '',
      address: '',
      logo: '',
      phone: 0,
      paymentDetails: '',
    };
  }
}
