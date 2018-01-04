import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PracticalSectionComponent } from './practical-section.component';

describe('PracticalSectionComponent', () => {
  let component: PracticalSectionComponent;
  let fixture: ComponentFixture<PracticalSectionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PracticalSectionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PracticalSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
