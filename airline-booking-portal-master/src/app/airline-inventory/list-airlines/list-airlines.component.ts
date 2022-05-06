import { Component, OnInit } from '@angular/core';
import { AirlineInventory } from 'src/app/models/interface/airline-inventory';
import { AirlineInventoryService } from 'src/app/services/airline-inventory.service';

@Component({
  selector: 'app-list-airlines',
  templateUrl: './list-airlines.component.html',
  styleUrls: ['./list-airlines.component.css']
})
export class ListAirlinesComponent implements OnInit {
  flight_name : Array<AirlineInventory>=[];
  id:number=0;

  constructor(private AirlineService:AirlineInventoryService) { }

  getallairlines(){
    return this.AirlineService.getAirline().subscribe(
     (res:any) => {this.flight_name=res.result}
    )
  }

  getairlinebyid(){
    return this.AirlineService.getAirlineById(this.id).subscribe((res:any)=>{console.log(res.result)})
  }
   removeAirport(FlightId:number)
   {
     this.AirlineService.deleteAirlineByID(FlightId)
     .subscribe(
       data=>{
         console.log(data);
         this.getallairlines();
       },
       error => console.log(error));
   }

  ngOnInit() {
    this.getallairlines()
  }

}
