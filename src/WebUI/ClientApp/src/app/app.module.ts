import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthModule } from '@auth0/auth0-angular';
import { AuthCallbackComponent } from '@pages/auth-callback/auth-callback.component';
import { SharedModule } from '@shared/shared.module';
import { environment } from '@env';
import { BearerTokenInterceptor, ErrorHandlerInterceptor } from '@services';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { effects, reducers } from '@core/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';

@NgModule({
  declarations: [AppComponent, AuthCallbackComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', loadChildren: () => import('./pages/shell/shell.module').then(m => m.ShellModule) },
      { path: 'auth-callback', component: AuthCallbackComponent },
    ]),
    SharedModule,
    BrowserAnimationsModule,
    StoreModule.forRoot(reducers),
    EffectsModule.forRoot(effects),
    StoreDevtoolsModule.instrument({maxAge: 25}),
    AuthModule.forRoot(environment.authConfig),
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: BearerTokenInterceptor,
    multi: true
  },{
    provide: HTTP_INTERCEPTORS,
    useClass: ErrorHandlerInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent],
})
export class AppModule {}
