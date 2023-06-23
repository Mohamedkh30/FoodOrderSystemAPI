// import { AgmCoreModule } from '@agm/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { JwtTokenInterceptor } from './Interceptors/jwt-token.interceptor';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { SharedModule } from './shared/shared.module';
import { ErrorModule } from './error/error.module';
import { HomeModule } from './home/home.module';
import { FormsModule } from '@angular/forms';
import { ProductModule } from './product/product.module';
import { HomePageComponent } from './home/home-page/home-page.component';
import { NavigationRegisterComponent } from './Registraion/navigation-register/navigation-register.component';

@NgModule({
  declarations: [AppComponent, NavbarComponent , NavigationRegisterComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ErrorModule,
    HomeModule,
    FormsModule,

    BrowserAnimationsModule,
    SharedModule,
    ErrorModule,
    ProductModule,

    // AgmCoreModule.forRoot({
    //   apiKey: 'AIzaSyBPfbHdhiBn2prqXNfZKa0yFYVPOWMVvKU', // Replace with your actual API key
    // }),
    // GoogleMapsModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtTokenInterceptor,
      multi: true,
    },
  ],

  bootstrap: [AppComponent],
})
export class AppModule {}
