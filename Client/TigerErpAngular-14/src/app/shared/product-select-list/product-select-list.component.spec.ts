import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductSelectListComponent } from './product-select-list.component';

describe('ProductSelectListComponent', () => {
  let component: ProductSelectListComponent;
  let fixture: ComponentFixture<ProductSelectListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductSelectListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductSelectListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
