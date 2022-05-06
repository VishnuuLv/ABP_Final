import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CouponService {

constructor(private httpclient:HttpClient) { }

getAllCoupons(){
  return this.httpclient.get( environment.baseurl + 'coupon');
}

getCouponById(id:number){
  return this.httpclient.get( environment.baseurl + 'admin/getcoupon/'+id);
}

deleteCouponByID(id:number){
  return this.httpclient.delete( environment.baseurl + 'admin/deletecoupon/'+id);
}

updateCouponByID(coupon:object){
  return this.httpclient.put( environment.baseurl + 'admin/addcoupon',coupon);
}

addCoupon(coupon:object){
  return this.httpclient.post( environment.baseurl + 'admin/addcoupon',coupon);
}

}
