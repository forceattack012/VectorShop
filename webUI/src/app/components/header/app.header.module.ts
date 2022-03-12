import { BasketCartItemHeaderComponent } from './basket-cart-item-header/basket-cart-item-header.component';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MainHeaderComponent } from './main-header/main-header.component';
import { SharedModule } from 'src/app/shared/app.shared.module';

@NgModule({
  imports: [
    CommonModule,
    SharedModule
  ],
  declarations: [
    MainHeaderComponent,
    BasketCartItemHeaderComponent
  ],
  exports: [
    MainHeaderComponent
  ]
})

export class HeaderModule {}
