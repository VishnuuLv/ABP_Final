import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CouponService {
token:any;
constructor(private httpclient:HttpClient) {
  this.token=sessionStorage.getItem('token');
 }

//  headers = new HttpHeaders({
//   'Authorization': this.token });
//  options = { headers: headers };




getAllCoupons(){
  return this.httpclient.get(environment.baseurl + 'coupon' ,
     { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)
     .append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')}
     )
}

getCouponById(id:number){
  return this.httpclient.get( environment.baseurl + 'admin/getcoupon/'+id,
  { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)
  .append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')}
  )
}

getCouponByName(couponCode:string){
  return this.httpclient.get( environment.baseurl + 'admin/getcouponbyname/'+couponCode,
  { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)
  .append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')}
  )
}

deleteCouponByID(id:number){
  return this.httpclient.delete( environment.baseurl + 'admin/deletecoupon/'+id,
  { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)
  .append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')}
  )
}

updateCouponByID(coupon:object){
  return this.httpclient.put( environment.baseurl + 'admin/addcoupon',coupon,
  { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)
  .append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')}
  )
}

addCoupon(coupon:object){
  return this.httpclient.post( environment.baseurl + 'admin/addcoupon',coupon,
  { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)
  .append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')}
  )
}

// getAllCoupons(){
//   return this.httpclient.get("https://flightservicescouponapi.azurewebsites.net/api/Coupon" ,
//      { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)}
//      )
// }

// getCouponById(id:number){
//   return this.httpclient.get( "https://flightservicescouponapi.azurewebsites.net/api/Coupon/" +id,
//   { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)}
//   )
// }

// getCouponByName(couponCode:string){
//   return this.httpclient.get( "https://flightservicescouponapi.azurewebsites.net/api/Coupon/GetCouponByName/"+couponCode,
//   { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)}
//   )
// }

// deleteCouponByID(id:number){
//   return this.httpclient.delete( "https://flightservicescouponapi.azurewebsites.net/api/Coupon/"+id,
//   { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)}
//   )
// }

// updateCouponByID(coupon:object){
//   return this.httpclient.put( "https://flightservicescouponapi.azurewebsites.net/api/Coupon",coupon,
//   { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)}
//   )
// }

// addCoupon(coupon:object){
//   return this.httpclient.post( "https://flightservicescouponapi.azurewebsites.net/api/Coupon",coupon,
//   { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)}
//   )
// }

}
