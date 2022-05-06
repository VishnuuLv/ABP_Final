import { Component, OnInit } from '@angular/core';
import { BookingSchedule } from 'src/app/models/interface/booking-schedule';
import { BookingScheduleService } from 'src/app/services/booking-schedule.service';

@Component({
  selector: 'app-list-all-bookings',
  templateUrl: './list-all-bookings.component.html',
  styleUrls: ['./list-all-bookings.component.css']
})
export class ListAllBookingsComponent implements OnInit {
   booking_details : Array<BookingSchedule>=[];
  id:number=0;

  constructor(private bookingService:BookingScheduleService) {
}
getAllBookings(){
  return this.bookingService.getAllBooking().subscribe(
   (res:any) => {console.log(res.result),this.booking_details=res.result}
  )
}



   removeBooking(bookingId:number)
   {
     this.bookingService.deleteBookingByID(bookingId)
     .subscribe(
       data=>{
         console.log(data);
         this.getAllBookings();
       },
       error => console.log(error));
   }

  ngOnInit() {
    this.getAllBookings();
  }

}
