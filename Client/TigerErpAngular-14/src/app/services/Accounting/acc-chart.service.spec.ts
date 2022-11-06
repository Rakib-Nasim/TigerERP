import { TestBed } from '@angular/core/testing';

import { AccChartService } from './acc-chart.service';

describe('AccChartService', () => {
  let service: AccChartService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AccChartService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
