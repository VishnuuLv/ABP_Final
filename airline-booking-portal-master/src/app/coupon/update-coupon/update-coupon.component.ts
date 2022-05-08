import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Coupon } from 'src/app/models/class/coupon';
import { CouponService } from 'src/app/services/coupon.service';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
  selector: 'app-update-coupon',
  templateUrl: './update-coupon.component.html',
  styleUrls: ['./update-coupon.component.css']
})
export class UpdateCouponComponent implements OnInit {
  id:number=0;
  coupon: Coupon=new Coupon();
  submitted=false;
  updateCouponForm: FormGroup;

  constructor(private fb: FormBuilder,private CouponService:CouponService,private notifyService : NotificationService,
    private router: Router,private route:ActivatedRoute) {
      this.updateCouponForm =  this.fb.group({
        couponCode: [null, Validators.required],
        discountPercentage: [null, Validators.required],
        maxAmount: [null, Validators.required],
        flightId: [null, Validators.required],
        validityStartDate: [null, Validators.required],
        validityEndDate: [null, Validators.required],
      } );
    }

  ngOnInit() {
    this.id= Number(this.route.snapshot.paramMap.get('id'));
    this.getcouponbyid();
  }
  onSubmit() {
    console.log(this.updateCouponForm.value);


    if (this.updateCouponForm.valid) {
        // this.user = Object.assign(this.user, this.registerationForm.value);
        this.CouponService.updateCouponByID(this.userData()).subscribe(() =>
        {
          this.notifyService.showSuccessMessage("Coupon Updated Successfully")
            this.onReset();
            this.submitted = true;
        });

    }
  }

  onReset() {
    this.submitted = false;
    this.updateCouponForm.reset();
  }


  userData(): Coupon {
    return this.coupon = {
      couponId:this.id,
      couponCode: this.couponCode.value,
      discountPercentage:this.discountPercentage.value,
      maxAmount: this.maxAmount.value,
      flightId: this.flightId.value,
      validityStartDate:this.validityStartDate.value,
      validityEndDate:this.validityEndDate.value
    };
  }

  get couponCode() {
  return this.updateCouponForm.get('couponCode') as FormControl;
  }

  get discountPercentage(){
    return this.updateCouponForm.get('discountPercentage') as FormControl
  }

  get maxAmount() {
  return this.updateCouponForm.get('maxAmount') as FormControl;
  }
  get flightId() {
  return this.updateCouponForm.get('flightId') as FormControl;
  }
  get validityStartDate() {
  return this.updateCouponForm.get('validityStartDate') as FormControl;
  }
  get validityEndDate() {
  return this.updateCouponForm.get('validityEndDate') as FormControl;
  }

  getcouponbyid(){
      return this.CouponService.getCouponById(this.id).subscribe((res:any)=>{
        console.log(res.result);
         this.updateCouponForm.setValue({
           couponCode: res.result.couponCode,
           discountPercentage:res.result.discountPercentage,
           maxAmount: res.result.maxAmount,
           flightId:res.result.flightId,
           validityStartDate:res.result.validityStartDate,
           validityEndDate:res.result.validityEndDate
        });
      })
    }

}
