import {Component, OnInit, ViewEncapsulation} from '@angular/core';
import {HomeClient} from "../customer/home/homeController";
import {Category, RFQsClient} from "./rfq.service";

@Component({
  moduleId: 'lsdjf',
  selector: 'app-rfq',
  templateUrl: './rfq.component.html',
  styleUrls: ['./rfq.component.css'],
  encapsulation: ViewEncapsulation.None,
  providers: [RFQsClient]
})
export class RfqComponent implements OnInit {
  template;
  categories: Category[];
  valueAddedServices: ValueAddedService[];

  constructor(private homeClient: HomeClient, private rFQsClient: RFQsClient) {
  }

  insertTemplate() {

  }

  ngOnInit() {

    this.valueAddedServices = new Array()
    this.valueAddedServices.push(new ValueAddedService('نیاز فوری ', ''));
    this.valueAddedServices.push(new ValueAddedService('تامین کنندگان بیشتر', ''));
    this.valueAddedServices.push(new ValueAddedService('کارشناس خرید', ''));
    this.valueAddedServices.push(new ValueAddedService('ترجمه به زبان های دیگر', ''));
  }


  selectCategory(ev: Category) {
    console.log('selectCategory', ev);
    this.rFQsClient.details(ev.id).toPromise().then(res => {
      console.log('this.rFQsClient.details', res);
      this.template = res.template;
    });
  }

  search(evq) {
    const ev = evq.query;
    this.rFQsClient.search(ev).toPromise().then(res => {
      console.log(res);
      this.categories = res;
    });
  }

  select(v: ValueAddedService) {
    v.selected = !v.selected;
  }

}


export class ValueAddedService {
  name;
  description;
  selected = false;

  constructor(name, description) {
    this.name = name;
    this.description = description;
  }
}
