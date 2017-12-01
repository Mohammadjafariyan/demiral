import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';


import {AppComponent} from './app.component';
import {LoginComponent} from './login/login.component';
import {RfqComponent} from './rfq/rfq.component';
import {HttpModule} from "@angular/http";
import {AppRoutingModule} from "./app-routing";
import {CustomerModule} from "./customer/customer.module";
import {AutoCompleteModule} from "primeng/primeng";
import {ImageUploadModule} from "angular2-image-upload";
import { LoginOnTheFlyComponent } from './login-on-the-fly/login-on-the-fly.component';

import {DialogModule} from 'primeng/primeng';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RfqComponent,
    LoginOnTheFlyComponent,


  ],
  imports: [
    BrowserModule, AppRoutingModule, CustomerModule, AutoCompleteModule,
    HttpModule,  ImageUploadModule.forRoot(),DialogModule
  ],
  providers: [HttpModule, BrowserModule],
  bootstrap: [AppComponent]
})
export class AppModule {
}
