import { NgModule  } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { NzI18nService } from 'ng-zorro-antd/i18n';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { NzGridModule } from 'ng-zorro-antd/grid';

import { WorkplaceRoutingModule } from './workplace-routing.module';
import { WorkplaceComponent } from './workplace.component';

import { WorkplaceReducer } from './store/reducer';
import { WorkplaceEffects } from './store/effects';

@NgModule({
  declarations: [WorkplaceComponent],
  imports: [
    CommonModule,
    WorkplaceRoutingModule,
    NzButtonModule,
    NzPaginationModule,
    NzGridModule,
    StoreModule.forFeature("workplace", WorkplaceReducer),
    EffectsModule.forFeature([WorkplaceEffects])
  ]
})
export class WorkplaceModule {
  constructor(private i18n: NzI18nService) {
    
  }
 }
