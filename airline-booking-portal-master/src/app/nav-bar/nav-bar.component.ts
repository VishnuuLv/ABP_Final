import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  role:String="";
  constructor(private router:Router) {
    this.role=String(sessionStorage.getItem('role'));
  }

  ngOnInit() {
  }

  logout(){
    sessionStorage.setItem("role","");
    sessionStorage.setItem("userId","");
    this.router.navigate(['']);

  }

}
