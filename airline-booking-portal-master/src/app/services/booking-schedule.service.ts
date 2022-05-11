import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BookingScheduleService {
  token:any;

constructor(private httpclient:HttpClient) {
  this.token=sessionStorage.getItem('token');
 }

getAllBooking(){
  return this.httpclient.get( environment.baseurl + 'allbooking-admin',
     { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)
     .append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')}
     )
}

getBookingByPNR(pnr:string){
  return this.httpclient.get( environment.baseurl + 'flight/booking/search/'+pnr,
     { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)
     .append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')}
     )
}

getBookingByID(id:number){
  return this.httpclient.get( environment.baseurl + 'flight/booking/history/userid/'+id,
     { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)
     .append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')}
     )
}

getPassengerList(id:number){
  return this.httpclient.get( environment.baseurl + 'flight/booking/passengerlist/'+id,
     { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)
     .append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')}
     )
}

deleteBookingByID(id:number){
  return this.httpclient.delete( environment.baseurl + 'flight/booking/cancel/'+id,
     { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)
     .append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')}
     )
}

updateBookingByID(booking:object){
  return this.httpclient.put( environment.baseurl + 'flight/booking',booking,
     { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)
     .append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')}
     )
}

addBooking(booking:object){
  return this.httpclient.post( environment.baseurl + 'flight/booking',booking,
     { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)
     .append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')}
     )
}

getSchedule(){
  return this.httpclient.get( environment.baseurl + 'flight/search',
     { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)
     .append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')}
     )
}
getAllSchedule(){
  return this.httpclient.get( environment.baseurl + 'flight/searchAll',
     { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)
     .append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')}
     )
}

getScheduleById(id:number){
  return this.httpclient.get( environment.baseurl + 'flight/GetScheduleByID/'+id,
     { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)
     .append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')}
     )
}

getScheduleByDate(d1:Date){
  return this.httpclient.get(environment.baseurl + 'flight/searchbydate/' + d1,
  { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)
  .append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')})
}
getScheduleBySAD(source:string,destination:string){
  return this.httpclient.get(environment.baseurl + 'flight/searchbysad/' + source+destination,
  { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)
  .append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')})
}
getScheduleBySDD(source:string,destination:string,d2:Date){
  return this.httpclient.get(environment.baseurl + 'flight/searchbysdd/' + source+"/"+destination+"/"+d2,
  { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)
  .append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')})
}

deleteScheduleByID(id:number){
  return this.httpclient.delete( environment.baseurl + 'flight/airline/delete/'+id,
     { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)
     .append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')}
     )
}

updateScheduleByID(schedule:object){
  return this.httpclient.put( environment.baseurl + 'flight/airline/register',schedule,
     { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)
     .append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')}
     )
}

addSchedule(schedule:object){
  return this.httpclient.post( environment.baseurl + 'flight/airline/register',schedule,
     { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)
     .append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')}
     )
}

// getAllBooking(){
//   return this.httpclient.get( "https://flightservicesbookingschedule.azurewebsites.net/api/Booking",
//      { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)}
//      )
// }

// getBookingByPNR(pnr:string){
//   return this.httpclient.get( "https://flightservicesbookingschedule.azurewebsites.net/api/Booking/GetBookingByPNR/"+pnr,
//      { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)}
//      )
// }

// getBookingByID(id:number){
//   return this.httpclient.get( "https://flightservicesbookingschedule.azurewebsites.net/api/Booking/GetByUserId/"+id,
//      { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)}
//      )
// }

// getPassengerList(id:number){
//   return this.httpclient.get( "https://flightservicesbookingschedule.azurewebsites.net/api/Booking/GetPassenger/"+id,
//      { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)}
//      )
// }

// deleteBookingByID(id:number){
//   return this.httpclient.delete( "https://flightservicesbookingschedule.azurewebsites.net/api/Booking/"+id,
//      { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)}
//      )
// }

// updateBookingByID(booking:object){
//   return this.httpclient.put( "https://flightservicesbookingschedule.azurewebsites.net/api/Booking",booking,
//      { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)}
//      )
// }

// addBooking(booking:object){
//   return this.httpclient.post( "https://flightservicesbookingschedule.azurewebsites.net/api/Booking",booking,
//      { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)}
//      )
// }

// getSchedule(){
//   return this.httpclient.get( "https://flightservicesbookingschedule.azurewebsites.net/api/Schedule/GetSchedule",
//      { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)}
//      )
// }
// getAllSchedule(){
//   return this.httpclient.get( "https://flightservicesbookingschedule.azurewebsites.net/api/Schedule/GetAllSchedule",
//      { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)}
//      )
// }

// getScheduleById(id:number){
//   return this.httpclient.get( "https://flightservicesbookingschedule.azurewebsites.net/api/Schedule/GetScheduleByID/"+id,
//      { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)}
//      )
// }

// getScheduleByDate(d1:Date){
//   return this.httpclient.get("https://flightservicesbookingschedule.azurewebsites.net/api/Schedule/" + d1)
// }
// getScheduleBySAD(source:string,destination:string){
//   return this.httpclient.get("https://flightservicesbookingschedule.azurewebsites.net/api/Schedule/" + source+destination)
// }
// getScheduleBySDD(source:string,destination:string,d2:Date){
//   return this.httpclient.get("https://flightservicesbookingschedule.azurewebsites.net/api/Schedule/" + source+"/"+destination+"/"+d2)
// }

// deleteScheduleByID(id:number){
//   return this.httpclient.delete( "https://flightservicesbookingschedule.azurewebsites.net/api/Schedule/RemoveSchedule/"+id,
//      { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)}
//      )
// }

// updateScheduleByID(schedule:object){
//   return this.httpclient.put( "https://flightservicesbookingschedule.azurewebsites.net/api/Schedule/UpdateSchedule",schedule,
//      { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)}
//      )
// }

// addSchedule(schedule:object){
//   return this.httpclient.post( "https://flightservicesbookingschedule.azurewebsites.net/api/Schedule/AddSchedule",schedule,
//      { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)}
//      )
// }

}
