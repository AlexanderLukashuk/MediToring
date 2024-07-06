import { Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { MedicationListComponent } from './medication/medication-list/medication-list.component';
import { MedicationDetailComponent } from './medication/medication-detail/medication-detail.component';
import { MedicationScheduleListComponent } from './medication-schedule/schedule-list/schedule-list.component';
import { MedicationScheduleDetailComponent } from './medication-schedule/schedule-detail/schedule-detail.component';

export const routes: Routes = [
  { path: 'auth/login', component: LoginComponent },
  { path: 'auth/register', component: RegisterComponent },
  { path: 'medication', component: MedicationListComponent },
  { path: 'medication/:id', component: MedicationDetailComponent },
  { path: 'medication-schedule', component: MedicationScheduleListComponent },
  { path: 'medication-schedule/:id', component: MedicationScheduleDetailComponent },
  { path: '', redirectTo: '/auth/login', pathMatch: 'full' }
];
