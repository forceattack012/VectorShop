import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/shared/models/product';
import { CatalogService } from 'src/app/services/catalog.service';
import { AuthenService } from 'src/app/core/authentication/authen.service';

@Component({
  selector: 'app-catalog-list',
  templateUrl: './catalog-list.component.html',
  styleUrls: ['./catalog-list.component.css']
})
export class CatalogListComponent implements OnInit {

  products: Product[] = [];

  constructor(private catalogService: CatalogService, private authenService: AuthenService) { }

  ngOnInit(): void {
    const user = this.authenService.getUser();
    console.log(user);
    this.catalogService.getAllProduct().subscribe(products => {
      this.products = products;
    });
  }

}
