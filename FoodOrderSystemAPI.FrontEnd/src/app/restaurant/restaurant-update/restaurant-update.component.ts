import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ImageService } from 'src/app/services/image.service';
import { RegistrationService } from 'src/app/services/registration.service';
import { RestaurantService } from 'src/app/services/restaurant.service';
import { RestaurantUpdateDto } from 'src/app/types/Restaurant/Restuarant-Update-Dto';
import { AuthentcationService } from 'src/app/services/authentcation.service';
import { RestaurantDetailsByIdDto } from 'src/app/types/Restaurant/Restaurant-Details-By-Id-dto';

@Component({
  selector: 'app-restaurant-update',
  templateUrl: './restaurant-update.component.html',
  styleUrls: ['./restaurant-update.component.css'],
})
export class RestaurantUpdateComponent {
  // Object That Hold The Form Date To Send to  Back end
  NewRestuarantUpdateDto: RestaurantUpdateDto = new RestaurantUpdateDto();
  CurrentLoggedInRestaurant: RestaurantDetailsByIdDto =
    new RestaurantDetailsByIdDto();
  //My Customer Form Hold all Elments
  UpdateResturantForm: FormGroup = new FormGroup('');

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private restaurantService: RestaurantService,
    public imageservice: ImageService,
    public authenticationService: AuthentcationService
  ) {}

  ngOnInit(): void {
    this.UpdateResturantForm = this.fb.group({
      Name: ['', [Validators.required]],
      Address: ['', [Validators.required]],
      PaymentMethods: ['', [Validators.required]],
      ResturnatLogo: [null, Validators.required],
    }); // Add the confirmPasswordValidator

    // FILLING DATA VALUES OF CURRENT RESTAURANT
    let currentLoggedInRestaurantId = this.authenticationService.UserLogin?.id;
    if (currentLoggedInRestaurantId != undefined) {
      this.restaurantService
        .getRestaurantDetailsById(currentLoggedInRestaurantId)
        .subscribe(
          (data) => {
            if (data !== null) this.CurrentLoggedInRestaurant = data;

            //  FILLING FORM WITH CURRENT RESTAURANT DATA
            this.ResturantName.setValue(
              this.CurrentLoggedInRestaurant.restaurantName
            );
            this.ResturantAddress.setValue(
              this.CurrentLoggedInRestaurant.address
            );
            this.ResturantPaymentMehods.setValue(
              this.CurrentLoggedInRestaurant.paymentMethods
            );
            this.ResturnatLogo.setValue(this.CurrentLoggedInRestaurant.logo);
          },
          (error) => {
            console.error(error);
          }
        );
    }
  }

  //#region   Get Properties To All Inputs Groups in Form
  get ResturantName() {
    return this.UpdateResturantForm.get('Name')!!;
  }
  get ResturantAddress() {
    return this.UpdateResturantForm.get('Address')!!;
  }
  get ResturantPaymentMehods() {
    return this.UpdateResturantForm.get('PaymentMethods')!!;
  }
  get ResturnatLogo() {
    return this.UpdateResturantForm.get('ResturnatLogo')!!;
  }
  //#endregion

  // When form Submit
  submitForm() {
    //TODO: EDIT SUBMIT FUNCTION
    if (this.UpdateResturantForm.valid) {
      // Form is valid, perform registration logic

      this.NewRestuarantUpdateDto.restaurantName = this.ResturantName.value;

      this.NewRestuarantUpdateDto.address = this.ResturantAddress.value;

      this.NewRestuarantUpdateDto.paymentMethods = Number.parseInt(
        this.ResturantPaymentMehods.value
      );
      this.NewRestuarantUpdateDto.logo = this.ResturnatLogo.value;

      console.log(this.NewRestuarantUpdateDto);

      this.restaurantService
        .UpdateRestaurant(this.NewRestuarantUpdateDto)
        .subscribe(
          (data) => {
            console.log('response: --------');
            console.log(data);
            this.router.navigate([
              `/restaurant/${this.CurrentLoggedInRestaurant.restaurantId}`,
            ]);
          },
          (error) => console.error(error)
        );
    } else {
      // Form is invalid, handle validation errors
      this.markFormGroupTouched(this.UpdateResturantForm); // Mark form controls as touched to display validation errors

      console.log(' Not valid ');
    }
  }

  // Function to mark all From Controls As Touched

  private markFormGroupTouched(formGroup: FormGroup) {
    Object.values(formGroup.controls).forEach((control) => {
      control.markAsTouched();
      if (control instanceof FormGroup) {
        this.markFormGroupTouched(control);
      }
    });
  }
}

//TODO: test with backend
