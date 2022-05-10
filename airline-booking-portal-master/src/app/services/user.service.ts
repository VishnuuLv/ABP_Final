import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  httpheader=new HttpHeaders();

constructor(private httpclient:HttpClient) {

}


// addNormalUser(user:object){
//   return this.httpclient.post( environment.baseurl + 'User/Register',user);
// }

// getUserById(id:number){
//   return this.httpclient.get( environment.baseurl + 'Userbyid/'+id);
// }

// getUsers(data:string,httpheader:any){
//   return this.httpclient.post('https://localhost:44384/connect/token',data,httpheader);
// }

// login(login:object){
//   return this.httpclient.post( environment.baseurl + 'Login',login);
// }

login(login:object){
  return this.httpclient.post("https://flightservicesusermanagement.azurewebsites.net/api/user/action",login);
}

addNormalUser(user:object){
  return this.httpclient.post( "https://flightservicesusermanagement.azurewebsites.net/api/user/Register",user);
}

getUserById(id:number){
  return this.httpclient.get( "https://flightservicesusermanagement.azurewebsites.net/api/user/"+id);
}


}
