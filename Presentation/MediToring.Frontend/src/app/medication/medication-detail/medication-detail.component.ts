import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { MedicationService } from '../medication.service';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-medication-detail',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './medication-detail.component.html',
  styleUrls: ['./medication-detail.component.css']
})
export class MedicationDetailComponent implements OnInit {
  medication: any;

  constructor(
    private route: ActivatedRoute,
    private medicationService: MedicationService
  ) { }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    this.medicationService.getMedication(id!).subscribe(
      data => {
        this.medication = data;
      },
      error => {
        console.error('Error fetching medication details', error);
      }
    );
  }
}
