import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AirlineInventoryService {

constructor(private httpclient:HttpClient) { }

getAirline(){
  return this.httpclient.get( environment.baseurl + 'flight/airline/inventory/getflights');
}
getAirlineById(id:number){
  return this.httpclient.get( environment.baseurl + 'flight/airline/inventory/searchbyid/'+id);
}

deleteAirlineByID(id:number){
  return this.httpclient.delete( environment.baseurl + 'flight/airline/inventory/delete/'+id);
}

updateAirlineByID(airport:object){
  return this.httpclient.put( environment.baseurl + 'flight/airline/inventory/add',airport);
}

addAirline(airport:object){
  return this.httpclient.post( environment.baseurl + 'flight/airline/inventory/add',airport);
}

}
