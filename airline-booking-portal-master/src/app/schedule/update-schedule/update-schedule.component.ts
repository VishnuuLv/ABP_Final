import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Schedule } from 'src/app/models/class/schedule';
import { AirlineInventory } from 'src/app/models/interface/airline-inventory';
import { AirlineInventoryService } from 'src/app/services/airline-inventory.service';
import { BookingScheduleService } from 'src/app/services/booking-schedule.service';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
  selector: 'app-update-schedule',
  templateUrl: './update-schedule.component.html',
  styleUrls: ['./update-schedule.component.css']
})
export class UpdateScheduleComponent implements OnInit {
  id:number=0;
  schedule: Schedule=new Schedule();
  submitted=false;
  updateScheduleForm: FormGroup;
  flight_name : Array<AirlineInventory>=[];

  constructor(private fb: FormBuilder,private ScheduleService:BookingScheduleService,
    private notifyService : NotificationService,
    private AirlineService:AirlineInventoryService,
    private router: Router,private route:ActivatedRoute) {
      this.updateScheduleForm =  this.fb.group({
         flightNumber: [null, Validators.required],
         flightId:'',
        fromPlace: [null, Validators.required],
        toPlace: [null, Validators.required],
        startDate: [null, Validators.required],
        endDate: [null, Validators.required],
        scheduledDays: [null, Validators.required],
        instrumentused: [null, Validators.required],
        economySeats: [null, Validators.required],
        businessClassSeats: [null, Validators.required],
        //totalSeats: [null, Validators.required],
        economyCost: [null, Validators.required],
        businessClassCost: [null, Validators.required],
        noOfRows: [null, Validators.required],
        meal: [null, Validators.required]
      } );
    }

  ngOnInit() {
    this.id= Number(this.route.snapshot.paramMap.get('id'));
    this.getSchedulebyId();
    this.getallairlines()
  }

  getallairlines(){
    return this.AirlineService.getAirline().subscribe(
     (res:any) => {this.flight_name=res.result}
    )
  }

  onSubmit() {
    //console.log(this.updateScheduleForm.value);


    if (this.updateScheduleForm.valid) {
        // this.user = Object.assign(this.user, this.registerationForm.value);
        this.ScheduleService.updateScheduleByID(this.userData()).subscribe(() =>
        {
          //console.log(this.userData());
          //console.log(this.id);
          this.notifyService.showSuccessMessage("Schedule Updated Successfully")
            this.onReset();
            this.submitted = true;
        });

    }
  }

  onReset() {
    this.submitted = false;
    this.updateScheduleForm.reset();
  }


  userData(): Schedule {
    return this.schedule = {
      scheduleDetailsId:this.id,
         flightNumber: this. flightNumber.value,
         flightId:this.flightId.value,
        fromPlace: this.fromPlace.value,
        toPlace: this.toPlace.value,
        startDate: this.startDate.value,
        endDate: this.endDate.value,
        scheduledDays: this.scheduledDays.value,
        instrumentused: this.instrumentused.value,
        economySeats: this.economySeats.value,
        businessClassSeats: this.businessClassSeats.value,
        //totalSeats: this.totalSeats.value,
        economyCost: this.economyCost.value,
        businessClassCost: this.businessClassCost.value,
        noOfRows: this.noOfRows.value,
        meal: this.meal.value
    };
  }

  get  flightNumber() {
  return this.updateScheduleForm.get('flightNumber') as FormControl;
  }

  get fromPlace() {
  return this.updateScheduleForm.get('fromPlace') as FormControl;
  }
  get toPlace() {
  return this.updateScheduleForm.get('toPlace') as FormControl;
  }

  get startDate() {
  return this.updateScheduleForm.get('startDate') as FormControl;
  }

  get endDate() {
  return this.updateScheduleForm.get('endDate') as FormControl;
  }
  get scheduledDays() {
  return this.updateScheduleForm.get('scheduledDays') as FormControl;
  }
  get instrumentused() {
  return this.updateScheduleForm.get('instrumentused') as FormControl;
  }

  get economySeats() {
  return this.updateScheduleForm.get('economySeats') as FormControl;
  }
  get businessClassSeats() {
  return this.updateScheduleForm.get('businessClassSeats') as FormControl;
  }

  // get totalSeats() {
  // return this.updateScheduleForm.get('totalSeats') as FormControl;
  // }

  get economyCost() {
  return this.updateScheduleForm.get('economyCost') as FormControl;
  }
  get businessClassCost() {
  return this.updateScheduleForm.get('businessClassCost') as FormControl;
  }
  get noOfRows() {
  return this.updateScheduleForm.get('noOfRows') as FormControl;
  }
  get meal() {
  return this.updateScheduleForm.get('meal') as FormControl;
  }

  get flightId() {
    return this.updateScheduleForm.get('flightId') as FormControl;
    }



  getSchedulebyId(){
      return this.ScheduleService.getScheduleById(this.id).subscribe((res:any)=>{
        console.log(res.result);
         this.updateScheduleForm.setValue({//newform is name
                flightId:res.result.flightId,
                flightNumber: res.result.flightNumber,
                fromPlace: res.result.fromPlace,
                toPlace: res.result.toPlace,
                startDate: res.result.startDate,
                endDate: res.result.endDate,
                scheduledDays: res.result.scheduledDays,
                instrumentused: res.result.instrumentused,
                economySeats: res.result.economySeats,
                businessClassSeats: res.result.businessClassSeats,
                //totalSeats: res.result.totalSeats,
                economyCost: res.result.economyCost,
                businessClassCost: res.result.businessClassCost,
                noOfRows: res.result.noOfRows,
                meal: res.result.meal
        });
      })
    }

}
