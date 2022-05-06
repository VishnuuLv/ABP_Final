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

  constructor(private couponService:CouponService) { }
  getallCoupons(){
    return this.couponService.getAllCoupons().subscribe(
     (res:any) => {this.coupon_name=res.result}
    )
  }

  getCouponById(){
    return this.couponService.getCouponById(this.id).subscribe((res:any)=>{console.log(res.result)})
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
    this.getallCoupons()
  }



}
