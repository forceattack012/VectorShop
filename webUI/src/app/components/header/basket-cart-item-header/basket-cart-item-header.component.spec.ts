import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BasketCartItemHeaderComponent } from './basket-cart-item-header.component';

describe('BasketCartItemHeaderComponent', () => {
  let component: BasketCartItemHeaderComponent;
  let fixture: ComponentFixture<BasketCartItemHeaderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BasketCartItemHeaderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BasketCartItemHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
