import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Passenger } from 'src/app/models/class/passenger';
import { BookingScheduleService } from 'src/app/services/booking-schedule.service';

@Component({
  selector: 'app-list-passengerby-bookingid',
  templateUrl: './list-passengerby-bookingid.component.html',
  styleUrls: ['./list-passengerby-bookingid.component.css']
})
export class ListPassengerbyBookingidComponent implements OnInit {
  id:number=0;
  passengers: Passenger=new Passenger();
  passenger_list:any;

  constructor(private bookingService:BookingScheduleService,
    private router: Router,private route:ActivatedRoute) { }

  ngOnInit() {
    this.id= Number(this.route.snapshot.paramMap.get('id'));
    this.getPassengersbyid();
  }

  getPassengersbyid(){
    return this.bookingService.getPassengerList(this.id).subscribe((res:any)=>{
      console.log(res.result);
      this.passenger_list =res.result;
    })

  }

}
