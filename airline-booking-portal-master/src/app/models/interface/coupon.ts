export interface Coupon {
  couponId :number,
  couponCode :string,
  discountPercentage : number,
  maxAmount:number,
  flightId:string,
  validityStartDate :Date,
  validityEndDate :Date,
  createdDate :Date,
  updatedDate:Date,
  isActive :string
}
