/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AirlineInventoryService } from './airline-inventory.service';

describe('Service: AirlineInventory', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AirlineInventoryService]
    });
  });

  it('should ...', inject([AirlineInventoryService], (service: AirlineInventoryService) => {
    expect(service).toBeTruthy();
  }));
});
