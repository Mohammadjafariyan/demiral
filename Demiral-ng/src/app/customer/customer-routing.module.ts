import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {HomeComponent} from './home/home.component';
import {CustomerAppComponent} from "./customer-app/customer-app.component";

const routes: Routes = [
  {
    path: '',
    component: CustomerAppComponent,
    children: [
      {path: 'home', component: HomeComponent},

    ]
  }

];
/*
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomerRoutingModule {
}*/
export const CustomerRoutingModule = RouterModule.forChild(routes)
