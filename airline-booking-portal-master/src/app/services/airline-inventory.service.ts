import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AirlineInventoryService {
  token:any;

constructor(private httpclient:HttpClient) {
  this.token=sessionStorage.getItem('token');
 }

getAirline(){
  return this.httpclient.get( environment.baseurl + 'flight/airline/inventory/getflights',
  { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)
  .append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')}
  )
}

getAirlineById(id:number){
  return this.httpclient.get( environment.baseurl + 'flight/airline/inventory/searchbyid/'+id,
  { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)
  .append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')}
  )
}

deleteAirlineByID(id:number){
  return this.httpclient.delete( environment.baseurl + 'flight/airline/inventory/delete/'+id,
  { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)
  .append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')}
  )
}

updateAirlineByID(airport:object){
  return this.httpclient.put( environment.baseurl + 'flight/airline/inventory/add',airport,
  { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)
  .append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')}
  )
}

addAirline(airport:object){
  return this.httpclient.post( environment.baseurl + 'flight/airline/inventory/add',airport,
  { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)
  .append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')}
  )
}

// getAirline(){
//   return this.httpclient.get( "https://flightservicesmanageapi.azurewebsites.net/api/Flights",
//   { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)}
//   )
// }

// getAirlineById(id:number){
//   return this.httpclient.get( "https://flightservicesmanageapi.azurewebsites.net/api/Flights/"+id,
//   { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)}
//   )
// }

// deleteAirlineByID(id:number){
//   return this.httpclient.delete( "https://flightservicesmanageapi.azurewebsites.net/api/Flights/"+id,
//   { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)}
//   )
// }

// updateAirlineByID(airport:object){
//   return this.httpclient.put( "https://flightservicesmanageapi.azurewebsites.net/api/Flights",airport,
//   { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)}
//   )
// }

// addAirline(airport:object){
//   return this.httpclient.post( "https://flightservicesmanageapi.azurewebsites.net/api/Flights",airport,
//   { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)}
//   )
// }

}
