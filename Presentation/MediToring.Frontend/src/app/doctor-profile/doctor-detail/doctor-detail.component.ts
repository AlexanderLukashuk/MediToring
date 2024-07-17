import { Component, OnInit } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { DoctorProfileService } from '../doctor-profile.service';

@Component({
  selector: 'app-doctor-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './doctor-detail.component.html',
  styleUrls: ['./doctor-detail.component.css'],
  providers: [DatePipe]
})
export class DoctorDetailComponent implements OnInit {
  doctor: any;

  constructor(
    private route: ActivatedRoute,
    private doctorProfileService: DoctorProfileService
  ) { }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.doctorProfileService.getDoctorById(id).subscribe(
        data => {
          this.doctor = data;
        },
        error => {
          console.error('Error fetching doctor details', error);
        }
      );
    }
  }
}
