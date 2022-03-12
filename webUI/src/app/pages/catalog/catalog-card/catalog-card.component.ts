import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from 'src/app/shared/models/product';
import { BasketService } from 'src/app/services/basket.service';

@Component({
  selector: 'app-catalog-card',
  templateUrl: './catalog-card.component.html',
  styleUrls: ['./catalog-card.component.css']
})
export class CatalogCardComponent implements OnInit {

  @Input() product = new Product();

  constructor(private router: Router, private basketService: BasketService) {
  }

  ngOnInit(): void {
  }

  gotoDetail(id: string | undefined): void {
    this.router.navigate([`catalog/${id}`]);
  }

  async addCartItem(): Promise<void> {
    this.basketService.addBasket('test', this.product);
    const basket = this.basketService.getBasket();
    await this.basketService.updateBasket(basket);
  }

}
