import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RestaurantApiTestComponent } from './restaurant-api-test.component';

describe('RestaurantApiTestComponent', () => {
  let component: RestaurantApiTestComponent;
  let fixture: ComponentFixture<RestaurantApiTestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RestaurantApiTestComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RestaurantApiTestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
