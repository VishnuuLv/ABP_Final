import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Schedule } from 'src/app/models/class/schedule';
import { AirlineInventory } from 'src/app/models/interface/airline-inventory';
import { AirlineInventoryService } from 'src/app/services/airline-inventory.service';
import { BookingScheduleService } from 'src/app/services/booking-schedule.service';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
  selector: 'app-add-schedule',
  templateUrl: './add-schedule.component.html',
  styleUrls: ['./add-schedule.component.css']
})
export class AddScheduleComponent implements OnInit {
  schedule: Schedule=new Schedule();
  submitted=false;
  addScheduleForm: FormGroup;
  flight_name : Array<AirlineInventory>=[];

  constructor(private fb: FormBuilder,private ScheduleService:BookingScheduleService,
    private notifyService : NotificationService,
    private AirlineService:AirlineInventoryService,
    private router: Router) {
      this.addScheduleForm =  this.fb.group({
        flightNumber: [null, Validators.required],
        flightId:[null, Validators.required],
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
    this.getallairlines()
  }

  getallairlines(){
    return this.AirlineService.getAirline().subscribe(
     (res:any) => {this.flight_name=res.result}
    )
  }
  onSubmit() {
    console.log(this.addScheduleForm.value);


    if (this.addScheduleForm.valid) {
        // this.user = Object.assign(this.user, this.registerationForm.value);
        this.ScheduleService.addSchedule(this.userData()).subscribe(() =>
        {

            this.onReset();
            this.submitted = true;
            this.notifyService.showSuccessMessage("Schedule Added Successfully")
        });

    }
  }

  onReset() {
    this.submitted = false;
    this.addScheduleForm.reset();
  }
  userData(): Schedule {
    return this.schedule = {
      scheduleDetailsId:0,
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
    return this.addScheduleForm.get('flightNumber') as FormControl;
    }

    get fromPlace() {
    return this.addScheduleForm.get('fromPlace') as FormControl;
    }
    get toPlace() {
    return this.addScheduleForm.get('toPlace') as FormControl;
    }

    get startDate() {
    return this.addScheduleForm.get('startDate') as FormControl;
    }

    get endDate() {
    return this.addScheduleForm.get('endDate') as FormControl;
    }
    get scheduledDays() {
    return this.addScheduleForm.get('scheduledDays') as FormControl;
    }
    get instrumentused() {
    return this.addScheduleForm.get('instrumentused') as FormControl;
    }

    get economySeats() {
    return this.addScheduleForm.get('economySeats') as FormControl;
    }
    get businessClassSeats() {
    return this.addScheduleForm.get('businessClassSeats') as FormControl;
    }

    // get totalSeats() {
    // return this.addScheduleForm.get('totalSeats') as FormControl;
    // }

    get economyCost() {
    return this.addScheduleForm.get('economyCost') as FormControl;
    }
    get businessClassCost() {
    return this.addScheduleForm.get('businessClassCost') as FormControl;
    }
    get noOfRows() {
    return this.addScheduleForm.get('noOfRows') as FormControl;
    }
    get meal() {
    return this.addScheduleForm.get('meal') as FormControl;
    }

    get flightId() {
      return this.addScheduleForm.get('flightId') as FormControl;
      }


}
