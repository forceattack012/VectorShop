import {Pipe, PipeTransform} from '@angular/core';


@Pipe({
  name: 'numberWithComma'
})
export class NumberWithComma implements PipeTransform {
  transform(value: number | undefined): string | undefined {
    const regex = /\d+/g;
    if (value === undefined) {
      return undefined;
    }
    if (!value.toString().match(regex)) {
      return undefined;
    }
    return value?.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
  }
}
