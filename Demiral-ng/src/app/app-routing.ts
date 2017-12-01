import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {RfqComponent} from "./rfq/rfq.component";

const routes: Routes = [
  {path: '', redirectTo: 'home', pathMatch: 'full'},
  {path: 'rfq', component: RfqComponent},


];

@NgModule({

  imports: [RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
