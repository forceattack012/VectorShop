import { ActivatedRoute, ParamMap } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/shared/models/product';
import { CatalogService } from 'src/app/services/catalog.service';

@Component({
  selector: 'app-catalog-detail',
  templateUrl: './catalog-detail.component.html',
  styleUrls: ['./catalog-detail.component.css']
})
export class CatalogDetailComponent implements OnInit {

  product: Product | undefined;

  constructor(private route: ActivatedRoute, private catalogService: CatalogService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe((paramMap: ParamMap) => {
      if(paramMap.has('id')) {
        const id = paramMap.get('id');
        this.catalogService.getProductById(id).subscribe(product => this.product = product);
      }
    });
  }

}
