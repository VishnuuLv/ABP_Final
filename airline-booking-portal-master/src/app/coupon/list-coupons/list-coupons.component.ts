import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CouponService } from 'src/app/services/coupon.service';

@Component({
  selector: 'app-list-coupons',
  templateUrl: './list-coupons.component.html',
  styleUrls: ['./list-coupons.component.css']
})
export class ListCouponsComponent implements OnInit {
  coupon_name:Array<any>=[];
  id:number=0;
  token:any;

  constructor(private couponService:CouponService,private httpclient:HttpClient) { }
  getallCoupons(){
     return this.couponService.getAllCoupons()
    //return this.httpclient.get('http://localhost:9000/api/v1.0/coupon' ,
    // { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)}
    // )
    .subscribe(
     (res:any) => {this.coupon_name=res.result}
    )
  }

  getCouponById(){
     return this.couponService.getCouponById(this.id)
    // this.httpclient.get('http://localhost:9000/api/v1.0/coupon' ,
    //  { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)}
    //  )
    .subscribe((res:any)=>{console.log(res.result)})
  }
   removeCoupon(couponId:number)
   {
     this.couponService.deleteCouponByID(couponId)
     .subscribe(
       data=>{
         console.log(data);
         this.getallCoupons();
       },
       error => console.log(error));
   }

  ngOnInit() {
    this.token=sessionStorage.getItem('token');
    console.log(this.token);
    this.getallCoupons()
    this.getCouponById()

  }

  // getWeather(){

  //   return this.httpclient.get('https://localhost:44349/WeatherForecast' ,
  //   { headers:new HttpHeaders().append('Authorization', `Bearer ${this.token}`)}
  //   ).subscribe((res:any)=>{});
  // }



}
