import { TestBed } from '@angular/core/testing';

import { ProductRelatedModelsService } from './product-related-models.service';

describe('ProductRelatedModelsService', () => {
  let service: ProductRelatedModelsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProductRelatedModelsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
