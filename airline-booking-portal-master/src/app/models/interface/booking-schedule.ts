export interface BookingSchedule {
  bookingId:number;
  scheduleDetailsId :number;
  userId :number;
  name:string;
  pnr:string;
  passengerId:number;
  passengerName:string;
  passengerGender:string;
  passengerAge:number;
  typeOfSeats:string;
  emailId:string;
  optForMeal:string;
  source:string
  destination:string
  departureDate:Date
  arrivalDate:Date
  originalTicketCost:number
  finalticketCost:number
  createdDate:Date;
  updatedDate:Date;
  isActive:string;
  flightNumber : string;
  fromPlace :string;
  toPlace :  string;
  startDate : Date;
  endDate : Date;
  scheduledDays :string;
  instrumentused :string;
  economySeats :number;
  businessClassSeats :number;
  totalSeats :number;
  economyCost :number;
  businessClassCost :number;
  noOfRows :number;
  meal :string;
}

