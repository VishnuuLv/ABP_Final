import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { BookingSchedule } from 'src/app/models/interface/booking-schedule';
import { BookingScheduleService } from 'src/app/services/booking-schedule.service';

@Component({
  selector: 'app-search-by-pnr',
  templateUrl: './search-by-pnr.component.html',
  styleUrls: ['./search-by-pnr.component.css']
})
export class SearchByPnrComponent implements OnInit {
  searchForm: FormGroup;
  booking_details : Array<BookingSchedule>=[];

  constructor(private bookingService:BookingScheduleService,private fb: FormBuilder) {
    this.searchForm =  this.fb.group({
      pnr:[null, Validators.required],

  });
}

  ngOnInit() {

  }



  getAllBookings(){
    return this.bookingService.getBookingByPNR(this.pnr.value).subscribe(
     (res:any) => {
       console.log(res.result),
       this.booking_details=res.result
      this.searchForm.reset()}
    )
  }

  get pnr() {
    return this.searchForm.get('pnr') as FormControl;
    }

}
