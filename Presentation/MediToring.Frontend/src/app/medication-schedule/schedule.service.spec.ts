import { TestBed } from '@angular/core/testing';

import { MedicationScheduleService } from './schedule.service';

describe('ScheduleService', () => {
  let service: MedicationScheduleService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MedicationScheduleService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
