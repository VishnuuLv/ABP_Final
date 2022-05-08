import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Login } from 'src/app/models/class/login';
import { User } from 'src/app/models/class/user';
import { NotificationService } from 'src/app/services/notification.service';
import { UserService } from 'src/app/services/user.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  //user_detail:User=new User();
  user: Login=new Login();
  submitted=false;
  addUserForm: FormGroup;





  constructor(private fb: FormBuilder,private UserService:UserService,private httpclient:HttpClient,
    private notifyService : NotificationService,private router: Router) {
    this.addUserForm =  this.fb.group({
      userName: [null,[ Validators.required,Validators.email]],
     // email: [null, Validators.required],
      password: [null, Validators.required],
    });
   }


  ngOnInit() {
  //  this.getUsers();
  //  this.getAdmin();
  }

  onSubmit() {
    //console.log(this.addUserForm.value);


    if (this.addUserForm.valid) {
        // this.user = Object.assign(this.user, this.registerationForm.value);
        this.UserService.login(this.userData()).subscribe((res:any) =>
        {
          //console.log(res);
          if(res.id>0){
            //this.user_detail=res;
            this.notifyService.showSuccess("Login Successfull", "ABP Portal")
            sessionStorage.setItem("role",res.role);
            sessionStorage.setItem("userId",res.id);
            //sessionStorage.setItem("token",res.token);
            if(res.role==="User")
            {
              this.getUsers();
            }
            else if(res.role==="Admin")
            {
              this.getAdmin();
            }
            this.router.navigate(['schedule']);
          }
          else
          {
            this.notifyService.showError("Username or Password is Incorrect", "ABP Portal")
          }
        });

    }
}

onReset() {
    this.submitted = false;
    this.addUserForm.reset();
}
getUsers(){
  const body = new HttpParams()
.set('client_id', 'user_client_id')
.set('client_secret', 'secret')
.set('grant_type', 'client_credentials')
.set('scope', 'apiscope')
//console.log(body.toString);
  return this.httpclient.post('http://localhost:9006/connect/token' ,body.toString(), {
    headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
  }).subscribe((res:any)=>{//console.log(res.access_token)
    sessionStorage.setItem("token",res.access_token);}
  );
}

getAdmin(){
  const body = new HttpParams()
.set('client_id', 'secret_client_id')
.set('client_secret', 'secret')
.set('grant_type', 'client_credentials')
.set('scope', 'apiscope')
//console.log(body.toString);
  return this.httpclient.post('http://localhost:9006/connect/token' ,body.toString(), {
    headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
  }).subscribe((res:any)=>{//console.log(res.access_token)
    sessionStorage.setItem("token",res.access_token);});
}


userData(): Login {
    return this.user = {
        userName: this.userName.value,
       // email: this.email.value,
        password: this.password.value,

    };
}

get userName() {
  return this.addUserForm.get('userName') as FormControl;
}


get password() {
  return this.addUserForm.get('password') as FormControl;
}


}
