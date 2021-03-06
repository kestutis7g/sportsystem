import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkoutCalendarComponent } from './workout-calendar.component';

describe('WorkoutCalendarComponent', () => {
  let component: WorkoutCalendarComponent;
  let fixture: ComponentFixture<WorkoutCalendarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WorkoutCalendarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkoutCalendarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
