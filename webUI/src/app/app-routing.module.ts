import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/account/login/login.component';
import { RegisterComponent } from './pages/account/register/register.component';
import { CatalogDetailComponent } from './pages/catalog/catalog-detail/catalog-detail.component';
import { CatalogListComponent } from './pages/catalog/catalog-list/catalog-list.component';

const routes: Routes = [
  {
    path: '',
    component: CatalogListComponent
  },
  {
    path: 'catalog/:id',
    component: CatalogDetailComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
