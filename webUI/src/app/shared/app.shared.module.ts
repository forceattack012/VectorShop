import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { NumberWithComma } from './pipes/numberWithComma';


@NgModule({
  imports: [
    CommonModule,
  ],
  declarations: [
    NumberWithComma
  ],
  exports: [
    NumberWithComma
  ],
})

export class SharedModule {

}
