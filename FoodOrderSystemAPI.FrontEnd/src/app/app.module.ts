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
import { NavigationRegisterComponent } from './Registraion/navigation-register/navigation-register.component';
import { HomePageComponent } from './home/home-page/home-page.component';


@NgModule({
  declarations: [AppComponent, NavbarComponent , HomePageComponent , NavigationRegisterComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule,
    ErrorModule,

   

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
