import { Product } from './product';

export class Basket {
  userName = '';
  items: Array<Product> = [];
  total: number = 0;
  totalItem = 0;
}
