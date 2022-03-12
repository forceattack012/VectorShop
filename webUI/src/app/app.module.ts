import { HeaderModule } from './components/header/app.header.module';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CatalogModule } from './pages/catalog/catalog.module';
import { FooterComponent } from './components/footer/footer.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { LoadingComponent } from './components/loading/loading.component';
import { SharedModule } from './shared/app.shared.module';
import { CoreModule } from './core/core.module';
import { AuthenCallbackComponent } from './components/authen-callback/authen-callback.component';
import { AuthenInterceptor } from './core/interceptor/authen.interceptor';
import { LoginComponent } from './pages/account/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AccountModule } from './pages/account/account.module';



@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    LoadingComponent,
    AuthenCallbackComponent,
  ],
  imports: [
    BrowserModule,
    SharedModule,
    HttpClientModule,
    HeaderModule,
    CatalogModule,
    CoreModule,
    AccountModule,
    AppRoutingModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthenInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
