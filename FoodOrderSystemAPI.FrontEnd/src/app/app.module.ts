import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CheckoutModule } from './checkout/checkout.module';
import { AddProductModule } from './add-product/add-product.module';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { SharedModule } from './shared/shared.module';
import { ErrorModule } from './error/error.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';





@NgModule({
  declarations: [
    AppComponent,

  ],
  imports: [
    BrowserModule,
    SharedModule,
    AppRoutingModule,
    ErrorModule,
    CommonModule,
    NgbModule,
    FormsModule,
    CheckoutModule,
    AddProductModule


  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
