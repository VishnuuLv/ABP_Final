export class Booking {
    scheduleDetailsId: number;
    userId: number;
    name: string;
    emailId: string;
    noOfSeats: number;
    //passengerName: string;
    //passengerGender: string;
    //passengerAge: number;
    //typeOfSeats: string;
    //optForMeal:string;
    couponCode: string;
    constructor(){
      this.scheduleDetailsId=0;
      this.userId=0;
      this.name="";
      this.emailId="";
      this.noOfSeats=0;
      //this.passengerName="";
      //this.passengerGender="";
      //this.passengerAge=0;
      //this.typeOfSeats="";
      //this.optForMeal="";
      this.couponCode="";
    }

}
