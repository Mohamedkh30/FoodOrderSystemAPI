import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, retry } from 'rxjs';
import { CustomerToRegisterDto } from '../types/customer-to-register-dto';
import { ResturantRegister } from '../types/resturant-register';
import { TokenDto } from '../types/token-dto';

@Injectable({
  providedIn: 'root',
})
export class RegistrationService {

  // If The Customer Is Registers 
  RegisterdCustomer: CustomerToRegisterDto = new CustomerToRegisterDto();

  // If Resturant Is Registers 
  RegisterResturant: ResturantRegister = new ResturantRegister();

  constructor(private httpclient: HttpClient) {}

  
  //Method To Customer Register
  Register(): Observable<TokenDto> {
    // Post requst to REgister End point That   Login the Registerd User and and Return TokenDto 
    const RegisterdCustomerTokenDto = this.httpclient.post<TokenDto>(
      'https://localhost:7020/api/Customer',
      this.RegisterdCustomer
    );
    return RegisterdCustomerTokenDto;
  }

    //Method To Customer Register

  RegisterAsResturant(): Observable<TokenDto> {
    // Post requst to REgister End point That   Login the Registerd User and and Return TokenDto 
    const RegisterdResturntTokenDto = this.httpclient.post<TokenDto>(
      'https://localhost:7020/api/restrurant',
      this.RegisterResturant
    );
    return RegisterdResturntTokenDto;
  }


}
