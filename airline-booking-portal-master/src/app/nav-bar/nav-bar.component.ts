import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  role:String="";
  userId:any;
  userName:any;
  lastName:any;
  constructor(private UserService:UserService,private router:Router) {
    this.role=String(sessionStorage.getItem('role'));
    this.userId=sessionStorage.getItem('userId');
  }

  ngOnInit() {
    this.getUserbyId()
  }

  getUserbyId(){
    return this.UserService.getUserById(this.userId).subscribe((res:any)=>{
      //console.log(res);
      this.userName=res.firstName;
      this.lastName=res.lastNmae;

    });
  }

  logout(){
    sessionStorage.setItem("role","");
    sessionStorage.setItem("userId","");
    sessionStorage.setItem("token","");
    this.router.navigate(['']);

  }

}
