import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ValidMsgComponent } from './valid-msg.component';

describe('ValidMsgComponent', () => {
  let component: ValidMsgComponent;
  let fixture: ComponentFixture<ValidMsgComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ValidMsgComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ValidMsgComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
