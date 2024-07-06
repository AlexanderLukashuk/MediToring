import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { MedicationScheduleService } from '../schedule.service';

@Component({
  selector: 'app-medication-schedule-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './schedule-detail.component.html',
  styleUrls: ['./schedule-detail.component.css']
})
export class MedicationScheduleDetailComponent implements OnInit {
  schedule: any;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private medicationScheduleService: MedicationScheduleService
  ) { }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.medicationScheduleService.getSchedule(id).subscribe(
        data => {
          console.log(data);
          this.schedule = data;
        },
        error => {
          console.error('Error fetching schedule details', error);
        }
      );
    } else {
      console.error('No ID found in route');
      this.router.navigate(['/medication-schedule']); // Navigate to the schedule list if no ID is found
    }
  }
}
