/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { BookingScheduleService } from './booking-schedule.service';

describe('Service: BookingSchedule', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BookingScheduleService]
    });
  });

  it('should ...', inject([BookingScheduleService], (service: BookingScheduleService) => {
    expect(service).toBeTruthy();
  }));
});
