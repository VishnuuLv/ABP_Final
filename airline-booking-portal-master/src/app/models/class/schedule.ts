export class Schedule {
  scheduleDetailsId : number;
  flightNumber : string;
  flightId:number;
  fromPlace :string;
  toPlace :  string;
  startDate : Date;
  endDate : Date;
  scheduledDays :string;
  instrumentused :string;
  economySeats :number;
  businessClassSeats :number;
  //totalSeats :number;
  economyCost :number;
  businessClassCost :number;
  noOfRows :number;
  meal :string;
  constructor(){
    this.scheduleDetailsId=0;
    this.flightNumber="";
    this.flightId=0;
    this.fromPlace="";
    this.toPlace="";
    this.startDate=new Date();
    this.endDate=new Date();
    this.scheduledDays="";
    this.instrumentused="";
    this.economySeats=0;
    this.businessClassSeats=0;
    //this.totalSeats=0;
    this.economyCost=0;
    this.businessClassCost=0;
    this.noOfRows=0;
    this.meal="";
  }
}
