import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginOnTheFlyComponent } from './login-on-the-fly.component';

describe('LoginOnTheFlyComponent', () => {
  let component: LoginOnTheFlyComponent;
  let fixture: ComponentFixture<LoginOnTheFlyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoginOnTheFlyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginOnTheFlyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
