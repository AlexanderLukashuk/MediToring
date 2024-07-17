import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DoctorProfileService } from '../doctor-profile.service';

@Component({
  selector: 'app-doctor-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './doctor-list.component.html',
  styleUrls: ['./doctor-list.component.css']
})
export class DoctorListComponent implements OnInit {
  doctors: any[] = [];

  constructor(private doctorProfileService: DoctorProfileService) { }

  ngOnInit() {
    this.doctorProfileService.getAllDoctors().subscribe(
      (data: any) => {
        if (Array.isArray(data)) {
          this.doctors = data;
        } else {
          console.error('Data is not an array', data);
        }
      },
      error => {
        console.error('Error fetching doctors', error);
      }
    );
  }
}
