import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MatrixMultiplicationComponent } from './matrix-multiplication.component';

describe('MatrixMultiplicationComponent', () => {
  let component: MatrixMultiplicationComponent;
  let fixture: ComponentFixture<MatrixMultiplicationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MatrixMultiplicationComponent]
    });
    fixture = TestBed.createComponent(MatrixMultiplicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
