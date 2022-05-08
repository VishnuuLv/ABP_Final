import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Airline } from 'src/app/models/class/airline';
import { AirlineInventoryService } from 'src/app/services/airline-inventory.service';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
  selector: 'app-add-airline',
  templateUrl: './add-airline.component.html',
  styleUrls: ['./add-airline.component.css']
})
export class AddAirlineComponent implements OnInit {
  airline: Airline=new Airline();
  submitted=false;
  addAirlineForm: FormGroup;

  constructor(private fb: FormBuilder,private AirlineService:AirlineInventoryService,private notifyService : NotificationService,private router: Router) {
    this.addAirlineForm =  this.fb.group({
      airlineName: [null, Validators.required],
      contactNumber:  [null, [Validators.required, Validators.maxLength(10)]],
      contactAddress: [null, Validators.required],
    });
  }

  ngOnInit() {
  }
  onSubmit() {
    console.log(this.addAirlineForm.value);


    if (this.addAirlineForm.valid) {
        // this.user = Object.assign(this.user, this.registerationForm.value);
        this.AirlineService.addAirline(this.userData()).subscribe(() =>
        {
            this.notifyService.showSuccessMessage("Airline Added Successfully")
            this.onReset();
            this.submitted = true;
        });

    }
}

onReset() {
    this.submitted = false;
    this.addAirlineForm.reset();
}


userData(): Airline {
    return this.airline = {
      flightId:0,
        flightName: this.airlineName.value,
        contactNumber: this.contactNumber.value,
        contactAddress: this.contactAddress.value,
        logoUrl:""
    };
}

get airlineName() {
  return this.addAirlineForm.get('airlineName') as FormControl;
}

get contactNumber() {
  return this.addAirlineForm.get('contactNumber') as FormControl;
}
get contactAddress() {
  return this.addAirlineForm.get('contactAddress') as FormControl;
}

}
