export class CustomerProfileDetails {
  fullName: string;
  role: string;
  email: string;
  longitude: number;
  latitude: number;
  cardNumber: string;
  expirationDate: string;
  cvvNumber: string;
  phone: string;
  customerBirth: string;

  constructor() {
    this.fullName = '';
    this.role = '';
    this.email = '';
    this.longitude = 0;
    this.latitude = 0;
    this.cardNumber = '';
    this.expirationDate = '';
    this.cvvNumber = '';
    this.phone = '';
    this.customerBirth = '';
  }
}
