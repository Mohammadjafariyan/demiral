import {ChangeDetectorRef, Component, OnInit, AfterViewInit} from '@angular/core';
import * as $ from 'jquery';
import {Category, HomeClient} from "./customer/home/homeController";
import {LoginServiceService} from "./login-on-the-fly/login-service.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [HomeClient, LoginServiceService]
})
export class AppComponent implements OnInit {
  title = 'app';
  categories: Category[];
  inRowsCategories: Category[];

  constructor(private homeClient: HomeClient, private cdr: ChangeDetectorRef,
              public LoginServiceService: LoginServiceService) {
  }


  getInRowsCategories() {
    return this.inRowsCategories;
  }


  ngOnInit() {


  }

}
