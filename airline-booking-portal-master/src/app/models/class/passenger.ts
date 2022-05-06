export class Passenger {
  passengerId:number;
  bookingId: number;
  passengerName:string;
  passengerGender:string;
  passengerAge:number;
  typeOfSeats:string;
  optForMeal:string;
    constructor(){
    this.passengerId=0;
    this.bookingId=0;
    this.passengerName="";
    this.passengerGender="";
    this.passengerAge=0;
    this.typeOfSeats="";
    this.optForMeal="";
      }
}

