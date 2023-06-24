import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder, AbstractControl ,ValidationErrors } from '@angular/forms';



@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  productForm: FormGroup;
  isSubmitted: boolean = false;
  photo: string = '';


  constructor(private formBuilder: FormBuilder) {
    this.productForm = this.formBuilder.group({
      photo: [''],
      product: ['', Validators.required],
      description: ['', Validators.required],
      price: ['', [Validators.required, Validators.min(1)]]
    });
  }

  ngOnInit() {}

  onFileInputClick() {
    document.getElementById('productImage')?.click();
  }

  // Method to delete the uploaded photo
  deletePhoto(): void {
    this.photo = '';
    const fileInput = document.getElementById('productImage') as HTMLInputElement;
    if (fileInput) {
      fileInput.value = ''; // Reset the value of the file input
      fileInput.disabled = false; // Re-enable the file input
    }
  }
  


  onFileChange(event: any): void {
    const fileInput = event.target as HTMLInputElement;
    if (fileInput?.files && fileInput.files.length) {
      this.photo = fileInput.files[0].name;
      fileInput.disabled = true;
    }
  }
  
  


  getFileName(): string {
    if (this.photo) {
      const fileInput = document.getElementById('productImage') as HTMLInputElement;
      return fileInput?.files && fileInput.files.length ? fileInput.files[0].name : '';
    }
    return '';
  }
  



  onSubmit() {
    this.isSubmitted = true;
    this.validateForm();

    if (this.productForm.valid) {
      // handle the form submission
    }
  }



  validateForm() {
    Object.keys(this.productForm.controls).forEach((field) => {
      const control = this.productForm.get(field);
      control?.markAsTouched();
    });
  }

  getControlErrorMessage(controlName: string): string {
    const control = this.productForm.get(controlName);

    if (this.isSubmitted && control?.invalid) {
      if (control?.errors?.['required']) {
        return 'This field is required.';
      }
    }

    return '';
  }
}

