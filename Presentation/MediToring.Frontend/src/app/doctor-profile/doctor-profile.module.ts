import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DoctorListComponent } from './doctor-list/doctor-list.component';
import { DoctorDetailComponent } from './doctor-detail/doctor-detail.component';

@NgModule({
  declarations: [
    DoctorListComponent,
    DoctorDetailComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    DoctorListComponent,
    DoctorDetailComponent
  ]
})
export class DoctorProfileModule { }
