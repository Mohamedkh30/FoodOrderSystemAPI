import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AddCardModule } from '../AddCard/add-card.module';
import { CheckoutComponent } from './checkout.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    CheckoutComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    AddCardModule,
    ReactiveFormsModule
  ],
  exports: [
    
  ]
})
export class CheckoutModule { }

