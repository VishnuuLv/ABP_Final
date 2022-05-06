export class Coupon {
  couponId:number;
  couponCode :string;
  discountPercentage : number;
  maxAmount:number;
  flightId:string;
  validityStartDate :Date;
  validityEndDate :Date;
  constructor(){
    this.couponId=0;
    this.couponCode="";
    this.discountPercentage=0;
    this.maxAmount=0;
    this.flightId="";
    this.validityStartDate=new Date(),
    this.validityEndDate=new Date()
      }
}
