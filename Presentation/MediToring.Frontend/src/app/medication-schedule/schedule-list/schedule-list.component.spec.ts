import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicationScheduleListComponent } from './schedule-list.component';

describe('ScheduleListComponent', () => {
  let component: MedicationScheduleListComponent;
  let fixture: ComponentFixture<MedicationScheduleListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MedicationScheduleListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MedicationScheduleListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
