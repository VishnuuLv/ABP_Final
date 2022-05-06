import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

constructor(private httpclient:HttpClient) { }

addNormalUser(user:object){
  return this.httpclient.post( environment.baseurl + 'User/Register',user);
}

getUserById(id:number){
  return this.httpclient.get( environment.baseurl + 'Userbyid/'+id);
}

login(login:object){
  return this.httpclient.post( environment.baseurl + 'Login',login);
}

}
