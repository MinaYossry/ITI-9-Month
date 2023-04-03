import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BindedInputComponent } from './binded-input.component';

describe('BindedInputComponent', () => {
  let component: BindedInputComponent;
  let fixture: ComponentFixture<BindedInputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BindedInputComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BindedInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
