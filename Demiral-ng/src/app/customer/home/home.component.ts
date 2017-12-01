import {ChangeDetectorRef, Component, OnInit, ViewEncapsulation} from '@angular/core';
import {Category, HomeClient} from "./homeController";
import * as $ from 'jquery';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  encapsulation: ViewEncapsulation.None,

})
export class HomeComponent implements OnInit {
  title = 'app';


  constructor(private homeClient: HomeClient, private cdr: ChangeDetectorRef) {
  }


  ngOnInit() {


  }
}
