import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CritiqueSectionComponent } from './critique-section.component';

describe('CritiqueSectionComponent', () => {
  let component: CritiqueSectionComponent;
  let fixture: ComponentFixture<CritiqueSectionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CritiqueSectionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CritiqueSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
