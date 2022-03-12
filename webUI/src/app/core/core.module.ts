import { NgModule } from '@angular/core';
import { AuthGuard } from './authentication/auth.guard';
import { AuthenService } from './authentication/authen.service';
import { AuthenInterceptor } from './interceptor/authen.interceptor';

@NgModule({
  providers: [
    AuthenService,
    AuthGuard,
    AuthenInterceptor
  ]
})

export class CoreModule {}
