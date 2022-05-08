import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedComponent } from './shared.component';
import { NavBarComponent } from 'src/app/nav-bar/nav-bar.component';
import { RouterModule } from '@angular/router';




@NgModule({
  declarations: [SharedComponent,NavBarComponent],
  imports: [
    CommonModule,RouterModule
  ]
})
export class SharedModule { }
