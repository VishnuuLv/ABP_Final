import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BookingScheduleService {

constructor(private httpclient:HttpClient) { }
getAllBooking(){
  return this.httpclient.get( environment.baseurl + 'allbooking-admin');
}

getBookingByPNR(pnr:string){
  return this.httpclient.get( environment.baseurl + 'flight/booking/search/'+pnr);
}

getBookingByID(id:number){
  return this.httpclient.get( environment.baseurl + 'flight/booking/history/userid/'+id);
}
getPassengerList(id:number){
  return this.httpclient.get( environment.baseurl + 'flight/booking/passengerlist/'+id);
}

deleteBookingByID(id:number){
  return this.httpclient.delete( environment.baseurl + 'flight/booking/cancel/'+id);
}

updateBookingByID(booking:object){
  return this.httpclient.put( environment.baseurl + 'flight/booking',booking);
}

addBooking(booking:object){
  return this.httpclient.post( environment.baseurl + 'flight/booking',booking);
}

getSchedule(){
  return this.httpclient.get( environment.baseurl + 'flight/search');
}
getAllSchedule(){
  return this.httpclient.get( environment.baseurl + 'flight/searchAll');
}

getScheduleById(id:number){
  return this.httpclient.get( environment.baseurl + 'flight/GetScheduleByID/'+id);
}

getScheduleByDate(d1:Date){
  return this.httpclient.get(environment.baseurl + 'flight/searchbydate/' + d1)
}
getScheduleBySAD(source:string,destination:string){
  return this.httpclient.get(environment.baseurl + 'flight/searchbysad/' + source+destination)
}
getScheduleBySDD(source:string,destination:string,d2:Date){
  return this.httpclient.get(environment.baseurl + 'flight/searchbysdd/' + source+"/"+destination+"/"+d2)
}

deleteScheduleByID(id:number){
  return this.httpclient.delete( environment.baseurl + 'flight/airline/delete/'+id);
}

updateScheduleByID(schedule:object){
  return this.httpclient.put( environment.baseurl + 'flight/airline/register',schedule);
}

addSchedule(schedule:object){
  return this.httpclient.post( environment.baseurl + 'flight/airline/register',schedule);
}

}
