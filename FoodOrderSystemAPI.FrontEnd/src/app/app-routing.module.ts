import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { NotFoundComponent } from './error/not-found/not-found.component';
import { HomePageComponent } from './home/home-page/home-page.component';


const routes: Routes = [
  {path:'home',component:HomePageComponent},
  {path:'',redirectTo:'home',pathMatch:'full'},
  {path:'**',component:NotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }