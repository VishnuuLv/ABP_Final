import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Login } from 'src/app/models/class/login';
import { User } from 'src/app/models/class/user';
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

  constructor(private fb: FormBuilder,private UserService:UserService,private router: Router) {
    this.addUserForm =  this.fb.group({
      userName: [null, Validators.required],
     // email: [null, Validators.required],
      password: [null, Validators.required],
    });
   }


  ngOnInit() {
  }

  onSubmit() {
    //console.log(this.addUserForm.value);


    if (this.addUserForm.valid) {
        // this.user = Object.assign(this.user, this.registerationForm.value);
        this.UserService.login(this.userData()).subscribe((res:any) =>
        {
          console.log(res);
            //this.user_detail=res;
            console.log(res);
            sessionStorage.setItem("role",res.role);
            sessionStorage.setItem("userId",res.id);
            this.router.navigate(['schedule']);
        });

    }
}

onReset() {
    this.submitted = false;
    this.addUserForm.reset();
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
