import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { RegistrationService } from 'src/app/services/registration.service';
import { Router } from '@angular/router';
import { ResturantRegister } from 'src/app/types/resturant-register';
import { AuthentcationService } from 'src/app/services/authentcation.service';
import { HttpErrorResponse } from '@angular/common/http';
@Component({
  selector: 'app-register-as-resturant',
  templateUrl: './register-as-resturant.component.html',
  styleUrls: ['./register-as-resturant.component.css'],
})
export class RegisterAsResturantComponent implements OnInit {
  // Object That Hold The Form Date To Send to  Back end
  RegisterResturant: ResturantRegister = new ResturantRegister();
  //My Customer Form Hold all Elments
  ResturantForm: FormGroup = new FormGroup('');

  constructor(
    private fb: FormBuilder,
    private RegisterService: RegistrationService,
    private router: Router,
    private AuthentcationService: AuthentcationService
  ) {}

  ngOnInit(): void {
    this.ResturantForm = this.fb.group(
      {
        Name: [
          '',
          [
            Validators.required,
            Validators.minLength(4),
            Validators.maxLength(30),
          ],
        ],
        Address: [
          '',
          [
            Validators.required,
            Validators.minLength(4),
            Validators.maxLength(30),
          ],
        ],
        Logo: [
          '',
          [Validators.required,
          ]],
        Phone: [
          '',
          [Validators.required,
            Validators.pattern('^[0-9]{11}$')]],
        PaymentMethods: [
          '',
          [Validators.required,
            Validators.email]],
        Password: [
          '',
          [Validators.required,
           ]],
      }
    ); // Add the confirmPasswordValidator
  }

  //  Get Properties To All Inputs Groups in Form
  get ResturantName() {
  return this.ResturantForm.get('Name')!!;
  }
  get ResturantAddress() {
    return this.ResturantForm.get('Address')!!;
  }
  get ResturantLogo() {
    return this.ResturantForm.get('Logo')!!;
  }
  get ResturantPhone() {
    return this.ResturantForm.get('Phone')!!;
  }
  get ResturantPaymentMehods() {
    return this.ResturantForm.get('PaymentMethods')!!;
  }
  get ResturantPassword() {
    return this.ResturantForm.get('Password')!!;
  }


  // When form Submit
  submitForm() {
    if (this.ResturantForm.valid) {
      // Form is valid, perform registration logic

      this.RegisterService.RegisterResturant.restaurantName =
        this.ResturantName.value;
      
      this.RegisterService.RegisterResturant.address =
        this.ResturantAddress.value;
      
      this.RegisterService.RegisterResturant.logo =
        this.ResturantLogo.value;
      
      this.RegisterService.RegisterResturant.phone =
        this.ResturantPhone.value;
      
      this.RegisterService.RegisterResturant.paymentMethods =
        this.ResturantPaymentMehods.value;
      this.RegisterService.RegisterAsResturant().subscribe( (RegisterResturantToken) => {
        console.log(RegisterResturantToken);
        this.AuthentcationService.SetUserDataAfterLogin(RegisterResturantToken);
        this.router.navigate(['/home/customers']);
      },
      (error: HttpErrorResponse) => {
        console.log(error);
      })
      this.router.navigate(['/home']);
    } else {
      // Form is invalid, handle validation errors
      this.markFormGroupTouched(this.ResturantForm); // Mark form controls as touched to display validation errors
      this.RegisterResturant.restaurantName = this.ResturantName.value;
      this.RegisterResturant.address = this.ResturantAddress.value;
      this.RegisterResturant.phone = this.ResturantPhone.value;
      this.RegisterResturant.logo = this.ResturantLogo.value;
      this.RegisterResturant.paymentMethods = this.ResturantPaymentMehods.value;
      console.log(' Not valid ');
      console.log(this.RegisterResturant);
    }
  }

  // Function to mark all From Controls As Touched

  markFormGroupTouched(formGroup: FormGroup) {
    Object.values(formGroup.controls).forEach((control) => {
      control.markAsTouched();
      if (control instanceof FormGroup) {
        this.markFormGroupTouched(control);
      }
    });
  }
  
}
 

