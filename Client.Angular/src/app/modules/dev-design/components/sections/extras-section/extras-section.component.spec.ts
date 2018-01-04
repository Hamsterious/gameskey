import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExtrasSectionComponent } from './extras-section.component';

describe('ExtrasSectionComponent', () => {
  let component: ExtrasSectionComponent;
  let fixture: ComponentFixture<ExtrasSectionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExtrasSectionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExtrasSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
