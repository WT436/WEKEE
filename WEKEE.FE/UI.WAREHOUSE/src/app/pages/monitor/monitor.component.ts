import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { GetMonitorAction } from './store/actions';
import { MonitorState } from './store/reducer';

@Component({
  selector: 'app-monitor',
  templateUrl: './monitor.component.html',
  styleUrls: ['./monitor.component.less']
})
export class MonitorComponent implements OnInit {
  state$: Observable<MonitorState>;

  loading$: boolean = false;

  constructor(private store: Store<{ monitor: MonitorState }>) { 
    this.state$ = store.pipe(select(state => state.monitor));
  }

  ngOnInit(): void {
    this.state$.pipe(map(x => {
      this.loading$ = x.loading;
    }))
    .subscribe();
    
    this.store.dispatch(new GetMonitorAction());
  }

}
