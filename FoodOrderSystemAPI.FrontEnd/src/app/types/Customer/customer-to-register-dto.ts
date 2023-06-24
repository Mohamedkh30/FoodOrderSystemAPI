export class CustomerToRegisterDto {


  firstName: string = '';
  lastName: string = '';
  email: string ='';
  password: string = '';
  langitude: number = 0;
  landitude: number = 0;
  cardNumber?: string = '';
  expirationDate: Date = new Date(Date.now());
  cvvNumber: string = ''
  phone: string = ''
  customerBirth: Date|null = null;



}






