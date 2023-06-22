import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, retry } from 'rxjs';
import { CustomerToRegisterDto } from '../types/customer-to-register-dto';
import { TokenDto } from '../types/token-dto';

@Injectable({
  providedIn: 'root',
})
export class RegistrationService {
  RegisterdCustomer: CustomerToRegisterDto = new CustomerToRegisterDto();
  constructor(private httpclient: HttpClient) {}

  Register(): Observable<TokenDto> {
    // Post requst to REgister End point That   Login the Registerd User and and Return TokenDto 
    const RegisterdCustomerTokenDto = this.httpclient.post<TokenDto>(
      'https://localhost:7020/api/Customer',
      this.RegisterdCustomer
    );
    return RegisterdCustomerTokenDto;
  }
}
