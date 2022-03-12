import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { CatalogCardComponent } from './catalog-card/catalog-card.component';
import { CatalogListComponent } from './catalog-list/catalog-list.component';
import { CatalogDetailComponent } from './catalog-detail/catalog-detail.component';
import { SharedModule } from 'src/app/shared/app.shared.module';

@NgModule({
  imports: [
    CommonModule,
    SharedModule
  ],
  declarations: [
    CatalogListComponent,
    CatalogCardComponent,
    CatalogDetailComponent
  ]
})

export class CatalogModule {}
