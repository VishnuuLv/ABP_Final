import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Airline } from 'src/app/models/class/airline';
import { AirlineInventoryService } from 'src/app/services/airline-inventory.service';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
  selector: 'app-update-airline',
  templateUrl: './update-airline.component.html',
  styleUrls: ['./update-airline.component.css']
})
export class UpdateAirlineComponent implements OnInit {
  id:number=0;
  airline: Airline=new Airline();
  submitted=false;
  addAirlineForm: FormGroup;

  constructor(private fb: FormBuilder,private AirlineService:AirlineInventoryService,
    private notifyService : NotificationService,
    private router: Router,private route:ActivatedRoute) {
    this.addAirlineForm =  this.fb.group({
      airlineName: [null, Validators.required],
      contactNumber:  [null, [Validators.required, Validators.maxLength(10)]],
      contactAddress: [null, Validators.required],
    } );
   }

  ngOnInit() {
    this.id= Number(this.route.snapshot.paramMap.get('id'));
    this.getairlinebyid();
  }


onSubmit() {
  console.log(this.addAirlineForm.value);


  if (this.addAirlineForm.valid) {
      // this.user = Object.assign(this.user, this.registerationForm.value);
      this.AirlineService.updateAirlineByID(this.userData()).subscribe(() =>
      {
        this.notifyService.showSuccessMessage("Airline Updated Successfully")
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
    flightId:this.id,
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

  getairlinebyid(){
    return this.AirlineService.getAirlineById(this.id).subscribe((res:any)=>{
      console.log(res.result);
       this.addAirlineForm.setValue({//newform is name
         airlineName: res.result.flightName,
         contactNumber: res.result.contactNumber,
         contactAddress:res.result.contactAddress
      });
    })
  }


}
