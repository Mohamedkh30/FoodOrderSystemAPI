import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormControl,
  Validators,
  FormBuilder,
  AbstractControl,
  ValidationErrors,
} from '@angular/forms';
import { AuthentcationService } from '../services/authentcation.service';
import { ImageService } from '../services/image.service';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css'],
})
export class AddProductComponent implements OnInit {
  productForm: FormGroup;
  isSubmitted: boolean = false;
  photo: string = '';
  imageUrl: string = '';

  constructor(
    private formBuilder: FormBuilder,
    public ProductService: ProductService,
    private AuthenticationService: AuthentcationService,
    public imageservice: ImageService
  ) {
    this.productForm = this.formBuilder.group({
      ProductName: ['', Validators.required],
      ProductPrice: [null, Validators.required],
      ProductImg: [null, Validators.required],
      ProductDescription: [],
      ProductOffer: [0],
      Vigiterian: [false, Validators.requiredTrue],
      Pizza: [false, Validators.requiredTrue],
      Pasta: [false, Validators.requiredTrue],
      Chicken: [false, Validators.requiredTrue],
    });
  }

  //  Get Properties To All Inputs Groups in Form

  get ProductName() {
    return this.productForm.get('ProductName')!!;
  }
  get ProductPrice() {
    return this.productForm.get('ProductPrice')!!;
  }
  get ProductImg() {
    return this.productForm.get('ProductImg')!!;
  }
  get ProductDescription() {
    return this.productForm.get('ProductDescription')!!;
  }
  get ProductOffer() {
    return this.productForm.get('ProductOffer')!!;
  }
  get Vigiterian() {
    return this.productForm.get('Vigiterian')!!;
  }
  get Pizza() {
    return this.productForm.get('Pizza')!!;
  }
  get Pasta() {
    return this.productForm.get('Pasta')!!;
  }
  get Chicken() {
    return this.productForm.get('Chicken')!!;
  }

  ngOnInit() {}

  validateForm() {
    Object.keys(this.productForm.controls).forEach((field) => {
      const control = this.productForm.get(field);
      control?.markAsTouched();
    });
  }

  submitForm() {
    
    
    if (this.productForm.valid) {
      this.AssigingFormToToProductService();
      console.log(this.ProductService.productToAdd)
     console.log( this.ProductService.productToAdd.img)
      // Send Request to server Add Product
      this.ProductService.AddProduct().subscribe((productid: number) => {
      }, (error: HttpErrorResponse) => {
        console.log(error)
      })
    }
    this.validateForm();
  }

  // Get Tags Values

GetTagsValues() :string []{
  const selectedTagsValues: string[] = [];
    console.log(this.productForm.controls);
  Object.keys(this.productForm.controls).forEach((key) => {
    console.log(key)
    const control = this.productForm.get(key);
    if (control?.value) {
      selectedTagsValues.push(key);
    }
  });
  return selectedTagsValues;
}

  // Get All 

  AssigingFormToToProductService() {
    this.ProductService.productToAdd.productname = this.ProductName.value;
    this.ProductService.productToAdd.describtion =
      this.ProductDescription.value;
    this.ProductService.productToAdd.tags = this.GetTagsValues();
    this.ProductService.productToAdd.price = this.ProductPrice.value;
    this.ProductService.productToAdd.offer = this.ProductOffer.value;
    this.ProductService.productToAdd.restaurantID =
      this.AuthenticationService.UserLogin?.id!!;
  }
}
