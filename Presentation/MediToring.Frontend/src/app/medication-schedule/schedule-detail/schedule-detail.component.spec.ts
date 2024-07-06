import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicationScheduleDetailComponent } from './schedule-detail.component';

describe('ScheduleDetailComponent', () => {
  let component: MedicationScheduleDetailComponent;
  let fixture: ComponentFixture<MedicationScheduleDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MedicationScheduleDetailComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MedicationScheduleDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
