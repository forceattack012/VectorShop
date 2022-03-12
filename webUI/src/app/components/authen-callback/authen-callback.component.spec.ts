import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthenCallbackComponent } from './authen-callback.component';

describe('AuthenCallbackComponent', () => {
  let component: AuthenCallbackComponent;
  let fixture: ComponentFixture<AuthenCallbackComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuthenCallbackComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AuthenCallbackComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
