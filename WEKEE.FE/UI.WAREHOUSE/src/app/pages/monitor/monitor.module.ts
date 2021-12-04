import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreModule } from '@ngrx/store';

import { MonitorRoutingModule } from './monitor-routing.module';
import { MonitorComponent } from './monitor.component';

import { MonitorReducer } from './store/reducer';

@NgModule({
  declarations: [MonitorComponent],
  imports: [
    CommonModule,
    MonitorRoutingModule,
    StoreModule.forFeature("monitor", MonitorReducer)
  ]
})
export class MonitorModule { }