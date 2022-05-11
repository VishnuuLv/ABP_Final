import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddAirlineComponent } from './airline-inventory/add-airline/add-airline.component';
import { ListAirlinesComponent } from './airline-inventory/list-airlines/list-airlines.component';
import { UpdateAirlineComponent } from './airline-inventory/update-airline/update-airline.component';
import { AuthComponent } from './authentication/user/auth/auth.component';
import { LoginComponent } from './authentication/user/login/login.component';
import { RegisterComponent } from './authentication/user/register/register.component';
import { AuthGuard } from './AuthGuard/auth.guard';
import { CreateBookingComponent } from './booking/create-booking/create-booking.component';
import { ListAllBookingsComponent } from './booking/list-all-bookings/list-all-bookings.component';
import { ListBookingbyIdComponent } from './booking/list-bookingby-id/list-bookingby-id.component';
import { ListPassengerbyBookingidComponent } from './booking/passenger/list-passengerby-bookingid/list-passengerby-bookingid.component';
import { SearchByPnrComponent } from './booking/search-by-pnr/search-by-pnr.component';
import { AddCouponComponent } from './coupon/add-coupon/add-coupon.component';
import { ListCouponsComponent } from './coupon/list-coupons/list-coupons.component';
import { UpdateCouponComponent } from './coupon/update-coupon/update-coupon.component';
import { AddScheduleComponent } from './schedule/add-schedule/add-schedule.component';
import { ListAllSchedulesComponent } from './schedule/list-all-schedules/list-all-schedules.component';
import { ListCurrentScheduleComponent } from './schedule/list-current-schedule/list-current-schedule.component';
import { UpdateScheduleComponent } from './schedule/update-schedule/update-schedule.component';
import { SharedComponent } from './SharedModule/shared/shared.component';


const routes: Routes = [
  {path:'',component:AuthComponent,
     children:[{path:'',component:LoginComponent},
               {path:'registerUser',component:RegisterComponent},

               ]},
  {path:'',component:SharedComponent,canActivate:[AuthGuard],
     children:[
        {path:'schedule',component:ListCurrentScheduleComponent},
        {path:'airline',component:ListAirlinesComponent},
        {path:'addnewairline', component: AddAirlineComponent},
        {path:'updateAirline/:id', component: UpdateAirlineComponent},
        {path:'schedulelist',component:ListAllSchedulesComponent},
        {path:'updateSchedule/:id', component: UpdateScheduleComponent},
        {path:'addnewschedule', component: AddScheduleComponent},
        {path:'couponManagement',component:ListCouponsComponent},
        {path:'addcoupon',component:AddCouponComponent},
        {path:'updatecoupon/:id',component:UpdateCouponComponent},
        {path:'listBookingbyid',component:ListBookingbyIdComponent},
        {path:'listBooking',component:ListAllBookingsComponent},
        {path:'listpassengers/:id',component:ListPassengerbyBookingidComponent},
        {path:'booknow/:id',component:CreateBookingComponent},
        {path:'searchbyPNR',component:SearchByPnrComponent}]
  },{path:'**',component:LoginComponent}];//to redirect if we put any wrong path

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
