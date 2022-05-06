import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { ListAirlinesComponent } from './airline-inventory/list-airlines/list-airlines.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddAirlineComponent } from './airline-inventory/add-airline/add-airline.component';
import { UpdateAirlineComponent } from './airline-inventory/update-airline/update-airline.component';
import { ListCurrentScheduleComponent } from './schedule/list-current-schedule/list-current-schedule.component';
import { ListAllSchedulesComponent } from './schedule/list-all-schedules/list-all-schedules.component';
import { UpdateScheduleComponent } from './schedule/update-schedule/update-schedule.component';
import { AddScheduleComponent } from './schedule/add-schedule/add-schedule.component';
import { AddCouponComponent } from './coupon/add-coupon/add-coupon.component';
import { UpdateCouponComponent } from './coupon/update-coupon/update-coupon.component';
import { ListCouponsComponent } from './coupon/list-coupons/list-coupons.component';
import { ListPassengerbyBookingidComponent } from './booking/passenger/list-passengerby-bookingid/list-passengerby-bookingid.component';
import { ListBookingbyIdComponent } from './booking/list-bookingby-id/list-bookingby-id.component';
import { ListAllBookingsComponent } from './booking/list-all-bookings/list-all-bookings.component';
import { CreateBookingComponent } from './booking/create-booking/create-booking.component';
import { AuthenticationModule } from './authentication/authentication.module';
import { SharedModule } from './SharedModule/shared/shared.module';


@NgModule({
  declarations: [
    AppComponent,
    ListAirlinesComponent,
    AddAirlineComponent,
    UpdateAirlineComponent,
    ListCurrentScheduleComponent,
    ListAllSchedulesComponent,
    UpdateScheduleComponent,
    AddScheduleComponent,
    AddCouponComponent,
    UpdateCouponComponent,
    ListCouponsComponent,
    ListBookingbyIdComponent,
    ListAllBookingsComponent,
    ListPassengerbyBookingidComponent,
    CreateBookingComponent
   ],
  imports: [
    HttpClientModule,
    BrowserModule,
    RouterModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,AuthenticationModule,SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
