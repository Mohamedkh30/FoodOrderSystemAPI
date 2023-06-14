import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { SharedModule } from './shared/shared.module';
import { ErrorModule } from './error/error.module';


@NgModule({
  declarations: [
    AppComponent,
    
  ],
  imports: [
    BrowserModule,
    SharedModule,
    AppRoutingModule,
    ErrorModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
