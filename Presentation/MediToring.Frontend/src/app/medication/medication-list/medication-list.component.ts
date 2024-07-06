import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MedicationService } from '../medication.service';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-medication-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './medication-list.component.html',
  styleUrls: ['./medication-list.component.css']
})
export class MedicationListComponent implements OnInit {
  medications: any[] = [];

  constructor(private medicationService: MedicationService) {}

  ngOnInit() {
    this.medicationService.getAllMedications().subscribe(
      (data: any) => {
        if (Array.isArray(data.medications)) {
          this.medications = data.medications;
        } else {
          console.error('Data is not an array', data);
        }
      },
      error => {
        console.error('Error fetching medications', error);
      }
    );
  }
}
