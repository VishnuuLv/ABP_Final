export class User {
  id:number;
  userName :string;
  firstName:string;
  lastName:string;
  role:string;
  passwordHash :string;
  constructor(){
    this.id=0;
    this.userName="";
    this.firstName="";
    this.lastName="";
    this.role="";
    this.passwordHash="";
  }
}

