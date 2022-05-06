/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ListPassengerbyBookingidComponent } from './list-passengerby-bookingid.component';

describe('ListPassengerbyBookingidComponent', () => {
  let component: ListPassengerbyBookingidComponent;
  let fixture: ComponentFixture<ListPassengerbyBookingidComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListPassengerbyBookingidComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListPassengerbyBookingidComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
