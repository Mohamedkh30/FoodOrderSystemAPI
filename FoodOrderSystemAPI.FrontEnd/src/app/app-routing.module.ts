import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { NotFoundComponent } from './error/not-found/not-found.component';
import { HomePageComponent } from './home/home-page/home-page.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { AddCardComponent } from './AddCard/add-card.component';
import { AddProductComponent } from './add-product/add-product.component';


const routes: Routes = [
  {path: 'checkout', component: CheckoutComponent},
  {path: 'addcard', component: AddCardComponent},
  {path: 'addproduct', component: AddProductComponent},
  {path:'home',component:HomePageComponent},
  {path:'',redirectTo:'home',pathMatch:'full'},
  {path:'**',component:NotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
