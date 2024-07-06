import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MedicationDetailComponent } from './medication-detail/medication-detail.component';
import { MedicationListComponent } from './medication-list/medication-list.component';

@NgModule({
  declarations: [MedicationDetailComponent, MedicationListComponent],
  imports: [CommonModule],
  exports: [MedicationDetailComponent, MedicationListComponent]
})
export class MedicationModule { }
