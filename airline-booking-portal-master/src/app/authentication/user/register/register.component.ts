import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/models/class/user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  user: User=new User();
  submitted=false;
  addUserForm: FormGroup;

  constructor(private fb: FormBuilder,private UserService:UserService,private router: Router) {
    this.addUserForm =  this.fb.group({
      userName: [null, Validators.required],
      firstName: [null, Validators.required],
      lastName: [null, Validators.required],
      role: '',
      passwordHash: [null, Validators.required],
    });
   }

  ngOnInit() {
  }

  onSubmit() {
    console.log(this.addUserForm.value);


    if (this.addUserForm.valid) {
        // this.user = Object.assign(this.user, this.registerationForm.value);
        this.UserService.addNormalUser(this.userData()).subscribe(() =>
        {
            this.onReset();
            this.submitted = true;
        });

    }
}

onReset() {
    this.submitted = false;
    this.addUserForm.reset();
}


userData(): User {
    return this.user = {
      id:0,
      userName: this.userName.value,
      firstName: this.firstName.value,
      lastName:this.lastName.value,
      role:this.role.value,
      passwordHash: this.passwordHash.value,

    };
}

get userName() {
  return this.addUserForm.get('userName') as FormControl;
}
get firstName() {
  return this.addUserForm.get('firstName') as FormControl;
}
get lastName() {
  return this.addUserForm.get('lastName') as FormControl;
}

get role() {
  return this.addUserForm.get('role') as FormControl;
}
get passwordHash() {
  return this.addUserForm.get('passwordHash') as FormControl;
}

}
