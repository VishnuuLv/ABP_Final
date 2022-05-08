import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { BookingSchedule } from 'src/app/models/interface/booking-schedule';
import { BookingScheduleService } from 'src/app/services/booking-schedule.service';
// import{ NgxPaginationModule} from 'ngx-pagination';

@Component({
  selector: 'app-list-all-schedules',
  templateUrl: './list-all-schedules.component.html',
  styleUrls: ['./list-all-schedules.component.css']
})
export class ListAllSchedulesComponent implements OnInit {
  schedule_details : Array<BookingSchedule>=[];
  id:number=0;
  page: number = 1;
  count: number = 0;
  tableSize: number = 5;
  tableSizes: any = [3, 6, 9, 12];
  searchForm: FormGroup;

  constructor(private scheduleService:BookingScheduleService,private fb: FormBuilder,private httpclient:HttpClient) {
    this.searchForm =  this.fb.group({
      fromPlace:[null, Validators.required],
      toPlace: [null, Validators.required],
      startDate: [null, Validators.required],
  });
  }

  ngOnInit() {
    this.getAllSchedule()
  }
  getAllSchedule(){
    return this.scheduleService.getAllSchedule().subscribe(
     (res:any) => {this.schedule_details=res.result}
    )
  }

  search(){

    return this.scheduleService.getScheduleBySDD(this.fromPlace.value,this.toPlace.value,this.startDate.value).subscribe(
      (res:any)=>{this.schedule_details=res.result}

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
  onTableDataChange(event: any) {
    this.page = event;
    this.getAllSchedule();
  }
  onTableSizeChange(event: any): void {
    this.tableSize = event.target.value;
    this.page = 1;
    this.getAllSchedule();
  }

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
