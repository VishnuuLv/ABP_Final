import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Coupon } from 'src/app/models/class/coupon';
import { CouponService } from 'src/app/services/coupon.service';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
  selector: 'app-add-coupon',
  templateUrl: './add-coupon.component.html',
  styleUrls: ['./add-coupon.component.css']
})
export class AddCouponComponent implements OnInit {
  coupon: Coupon=new Coupon();
  submitted=false;
  addCouponForm: FormGroup;

  constructor(private fb: FormBuilder,private CouponService:CouponService,private notifyService : NotificationService,
    private router: Router) {
    this.addCouponForm =  this.fb.group({
      couponCode: [null, Validators.required],
      discountPercentage: [null, Validators.required],
      maxAmount: [null, Validators.required],
      flightId: [null, Validators.required],
      validityStartDate: [null, Validators.required],
      validityEndDate: [null, Validators.required],
    } );
   }

  ngOnInit() {
  }

  onSubmit() {
    console.log(this.addCouponForm.value);


    if (this.addCouponForm.valid) {
        // this.user = Object.assign(this.user, this.registerationForm.value);
        this.CouponService.addCoupon(this.userData()).subscribe(() =>
        {
            this.onReset();
            this.notifyService.showSuccessMessage("Coupon Added Successfully")
            this.submitted = true;
        });

    }
  }

  onReset() {
    this.submitted = false;
    this.addCouponForm.reset();
  }

  userData(): Coupon {
    return this.coupon = {
      couponId:0,
      couponCode: this.couponCode.value,
      discountPercentage:this.discountPercentage.value,
      maxAmount: this.maxAmount.value,
      flightId: this.flightId.value,
      validityStartDate:this.validityStartDate.value,
      validityEndDate:this.validityEndDate.value
    };
  }

  get couponCode() {
  return this.addCouponForm.get('couponCode') as FormControl;
  }

  get discountPercentage(){
    return this.addCouponForm.get('discountPercentage') as FormControl
  }

  get maxAmount() {
  return this.addCouponForm.get('maxAmount') as FormControl;
  }
  get flightId() {
  return this.addCouponForm.get('flightId') as FormControl;
  }
  get validityStartDate() {
  return this.addCouponForm.get('validityStartDate') as FormControl;
  }
  get validityEndDate() {
  return this.addCouponForm.get('validityEndDate') as FormControl;
  }

}
