import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RestaurantRoutingModule } from './restaurant-routing.module';
import { CustomersComponent } from 'src/app/home/customers/customers.component';

@NgModule({
    declarations: [ CustomersComponent ],
    imports: [
        CommonModule,
        RestaurantRoutingModule
    ]
})
export class RestaurantModule { }