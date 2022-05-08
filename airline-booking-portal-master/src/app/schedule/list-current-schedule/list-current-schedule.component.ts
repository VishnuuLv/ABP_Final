import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { BookingSchedule } from 'src/app/models/interface/booking-schedule';
import { BookingScheduleService } from 'src/app/services/booking-schedule.service';

@Component({
  selector: 'app-list-current-schedule',
  templateUrl: './list-current-schedule.component.html',
  styleUrls: ['./list-current-schedule.component.css']
})
export class ListCurrentScheduleComponent implements OnInit {
  schedule_details : Array<BookingSchedule>=[];
  id:number=0;
  searchForm: FormGroup;
  token:any;

  constructor(private scheduleService:BookingScheduleService,private fb: FormBuilder,private httpclient:HttpClient) {
    this.searchForm =  this.fb.group({
      fromPlace:[null, Validators.required],
      toPlace: [null, Validators.required],
      startDate: [null, Validators.required],
  });
   }

  ngOnInit() {
    this.getAllSchedule();
    this.token=sessionStorage.getItem('token');
    //console.log(this.token);
    //this.getWeather();
  }
  getAllSchedule(){
    return this.scheduleService.getSchedule().subscribe(
     (res:any) => {this.schedule_details=res.result}
    )
  }



  search(){

    return this.scheduleService.getScheduleBySDD(this.fromPlace.value,this.toPlace.value,this.startDate.value).subscribe(
      (res:any)=>{this.schedule_details=res.result}

    )
  }

  // getScheduleById(){
  //   return this.scheduleService.getScheduleById(this.id).subscribe((res:any)=>{console.log(res.result)})
  // }
  //  removeSchedule(scheduleId:number)
  //  {
  //    this.scheduleService.deleteScheduleByID(scheduleId)
  //    .subscribe(
  //      data=>{
  //        console.log(data);
  //        this.getAllSchedule();
  //      },
  //      error => console.log(error));
  //  }
  get fromPlace() {
    return this.searchForm.get('fromPlace') as FormControl;
    }
    get toPlace() {
      return this.searchForm.get('toPlace') as FormControl;
      }

      get startDate() {
      return this.searchForm.get('startDate') as FormControl;
      }

}
