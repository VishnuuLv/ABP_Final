import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './user/login/login.component';
import { RegisterComponent } from './user/register/register.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AuthComponent } from './user/auth/auth.component';
import { RouterModule } from '@angular/router';




@NgModule({
  declarations: [LoginComponent,RegisterComponent, AuthComponent],
  imports: [
    CommonModule,ReactiveFormsModule,RouterModule
  ]
})
export class AuthenticationModule { }
