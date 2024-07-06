import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MedicationScheduleService } from '../schedule.service';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-medication-schedule-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './schedule-list.component.html',
  styleUrls: ['./schedule-list.component.css']
})
export class MedicationScheduleListComponent implements OnInit {
  schedules: any[] = [];

  constructor(private medicationScheduleService: MedicationScheduleService) {}

  ngOnInit() {
    this.medicationScheduleService.getAllSchedules().subscribe(
      (data: any) => {
        if (Array.isArray(data.schedules)) {
          this.schedules = data.schedules;
        } else {
          console.error('Data is not an array', data);
        }
      },
      error => {
        console.error('Error fetching schedules', error);
      }
    );
  }
}
