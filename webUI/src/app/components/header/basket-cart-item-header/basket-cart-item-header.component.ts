import { Component, OnInit } from '@angular/core';
import { Basket } from 'src/app/shared/models/basket';
import { BasketService } from 'src/app/services/basket.service';
import { HubConnectionService } from 'src/app/services/hub-connection.service';

@Component({
  selector: 'app-basket-cart-item-header',
  templateUrl: './basket-cart-item-header.component.html',
  styleUrls: ['./basket-cart-item-header.component.css']
})
export class BasketCartItemHeaderComponent implements OnInit {

  basket: Basket = new Basket();
  dropdownOpen: boolean = false;

  constructor(private hubConnectionService: HubConnectionService, private basketService: BasketService) { }

  ngOnInit(): void {
    const hubConnection = this.hubConnectionService.startConnection();
    hubConnection?.on('sendBasketCartEvent' , (result) => {
      this.basket = result;
      console.log(this.basket);
    });
  }

  async removeBaskItemByIndex(userName: string, index: number): Promise<void> {
   if (userName !== this.basket.userName) {
    return;
   }
   const basketItemRemoved = new Basket();
   basketItemRemoved.userName = userName;
   basketItemRemoved.items = [...this.basket.items];
   basketItemRemoved.items.splice(index, 1);

   this.basketService.removeBasketByIndex(index);
   await this.basketService.updateBasket(basketItemRemoved);
  }
}
