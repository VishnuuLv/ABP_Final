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


 addNormalUser(user:object){
   return this.httpclient.post( environment.baseurl + 'User/Register',user,
   { headers:new HttpHeaders().append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')});
 }

 getUserById(id:number){
   return this.httpclient.get( environment.baseurl + 'Userbyid/'+id,
   { headers:new HttpHeaders().append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')});
 }

//  getUsers(data:string,httpheader:any){
//    return this.httpclient.post('https://localhost:44384/connect/token',data,httpheader);
//  }

 login(login:object){
   return this.httpclient.post( environment.baseurl + 'Login',login,
   { headers:new HttpHeaders().append('Ocp-Apim-Subscription-Key','b6c2e78f15104353b6283c9eae950893')}
   );
 }


// login(login:object){
//   return this.httpclient.post("https://flightservicesusermanagement.azurewebsites.net/api/user/action",login);
// }

// addNormalUser(user:object){
//   return this.httpclient.post( "https://flightservicesusermanagement.azurewebsites.net/api/user/Register",user);
// }

// getUserById(id:number){
//   return this.httpclient.get( "https://flightservicesusermanagement.azurewebsites.net/api/user/"+id);
// }


}
