import { Component, OnInit } from '@angular/core';
import { BookingSchedule } from 'src/app/models/interface/booking-schedule';
import { BookingScheduleService } from 'src/app/services/booking-schedule.service';

@Component({
  selector: 'app-list-all-schedules',
  templateUrl: './list-all-schedules.component.html',
  styleUrls: ['./list-all-schedules.component.css']
})
export class ListAllSchedulesComponent implements OnInit {
  schedule_details : Array<BookingSchedule>=[];
  id:number=0;

  constructor(private scheduleService:BookingScheduleService) { }

  ngOnInit() {
    this.getAllSchedule()
  }
  getAllSchedule(){
    return this.scheduleService.getAllSchedule().subscribe(
     (res:any) => {this.schedule_details=res.result}
    )
  }

  removeSchedule(scheduleId:number){
    return this.scheduleService.deleteScheduleByID(scheduleId).subscribe
    (data=>{
      console.log(data);
      this.getAllSchedule();
    },
      error => console.log(error));
  }

}
