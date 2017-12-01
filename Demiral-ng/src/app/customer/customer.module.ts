import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {CustomerRoutingModule} from './customer-routing.module';
import {HomeComponent} from "./home/home.component";
import { CustomerAppComponent } from './customer-app/customer-app.component';

@NgModule({
  imports: [
    CommonModule,
    CustomerRoutingModule,

  ],
  declarations: [HomeComponent, CustomerAppComponent],
  bootstrap: [CustomerAppComponent]
})
export class CustomerModule {
}
