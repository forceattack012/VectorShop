import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Basket } from '../shared/models/basket';
import { Product } from '../shared/models/product';

@Injectable({
  providedIn: 'root'
})
export class BasketService {

  basket: Basket;

  constructor(private http: HttpClient) {
    this.basket = new Basket();
  }

  async updateBasket(basket: Basket): Promise<Basket> {
    return this.http.post<Basket>('/api/basket', basket).toPromise();
  }

  addBasket(name: string, product: Product): void {
    this.basket.userName = name;
    product.quitity -= product.quitity - 1;
    this.basket.items.push(product);
  }

  getBasket(): Basket {
    return this.basket;
  }

  removeBasketByIndex(index: number): void {
    this.basket.items.splice(index, 1);
  }
}
