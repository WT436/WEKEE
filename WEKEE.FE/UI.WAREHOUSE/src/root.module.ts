import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { EffectsModule } from '@ngrx/effects';

/** config angular i18n **/
import { LOCALE_ID } from '@angular/core';
import { registerLocaleData } from '@angular/common';
import localeEn from '@angular/common/locales/en';
import localeJa from '@angular/common/locales/ja';
registerLocaleData(localeEn);
registerLocaleData(localeJa);

/** config ng-zorro-antd i18n **/
import { NZ_I18N, NzI18nService, en_US, ja_JP } from 'ng-zorro-antd/i18n';

import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { IconsProviderModule } from './icons-provider.module';

import { environment } from './environments/environment.prod';
import { RequestInterceptor } from './requestInterceptor';

import { RootRoutingModule } from './root-routing.module';
import { RootComponent } from './root.component';

import { NzNotificationModule } from 'ng-zorro-antd/notification';

@NgModule({
  declarations: [
    RootComponent
  ],
  imports: [
    BrowserModule,
    RootRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    IconsProviderModule,
    
    StoreModule.forRoot({}),
    EffectsModule.forRoot([]),
    StoreDevtoolsModule.instrument({
      name: 'NgRxApp',
      logOnly: environment.production
    }),
    
    NzNotificationModule
  ],
  providers: [
    /** set the default i18n config **/
    { 
      provide: NZ_I18N, 
      useFactory: (localId: string) => {
        switch (localId) {
          case 'en':
            return en_US;
          /** keep the same with angular.json/i18n/locales configuration **/
          case 'ja':
            return ja_JP;
          default:
            return en_US;
        }
      },
      deps: [LOCALE_ID]
    },
    { provide: HTTP_INTERCEPTORS, useClass: RequestInterceptor, multi: true }
  ],
  bootstrap: [RootComponent]
})
export class RootModule { 
  constructor(private i18n: NzI18nService) {
    
  }

  switchLanguage() {
    this.i18n.setLocale(ja_JP);
  }
}
