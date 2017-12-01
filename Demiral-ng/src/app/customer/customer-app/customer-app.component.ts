import {ChangeDetectorRef, Component, OnInit, ViewEncapsulation} from '@angular/core';
import * as $ from 'jquery';
import {Category, HomeClient} from "../home/homeController";

@Component({
  selector: 'app-customer-app',
  templateUrl: './customer-app.component.html',
  styleUrls: ['./customer-app.component.css'],
  encapsulation: ViewEncapsulation.None,
  providers: [HomeClient]

})
export class CustomerAppComponent implements OnInit {

  title = 'app';
  categories: Category[];
  inRowsCategories: Category[];

  constructor(private homeClient: HomeClient, private cdr: ChangeDetectorRef) {
  }


  getInRowsCategories() {
    return this.inRowsCategories;
  }

  row = 0;


  getInRows(category: Category) {
    let name = '';
    this.inRowsCategories = new Array();
    this.categories.forEach(c => {
      if (c.row === category.row) {
        this.inRowsCategories.push(c);
        //   c.isShowed = true;
        name += c.name + ' /';
      }
    });
    this.row++;

    // this.cdr.detectChanges();

    return name;
  }


  ngOnInit() {

    this.homeClient.getCategories().toPromise().then(res => {
      this.categories = res;
      var head = document.getElementsByTagName('head')[0];
      var script = document.createElement('script');
      script.type = 'text/javascript';
      script.src = $('#MegaDropdown').attr('src');
      head.appendChild(script);
    });

    $('#custom_carousel').on('slide.bs.carousel', function (evt) {
      $('#custom_carousel .controls li.active').removeClass('active');
      $('#custom_carousel .controls li:eq(' + $(evt.relatedTarget).index() + ')').addClass('active');
    });


  }

}
