import { Component, OnInit } from '@angular/core';

import { Store, select } from '@ngrx/store';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { GetToDoBeginAction, CreateToDoAction } from './store/action';
import ToDo from './dtos/todo';
import { WorkplaceState } from './store/reducer';

@Component({
  selector: 'app-workplace',
  templateUrl: './workplace.component.html',
  styleUrls: ['./workplace.component.less']
})
export class WorkplaceComponent implements OnInit {
  state$: Observable<WorkplaceState>;
  toDoList: ToDo[] = [];

  constructor(private store: Store<{ workplace: WorkplaceState }>) {
    this.state$ = store.pipe(select(state => state.workplace));
  }

  ngOnInit(): void {
    this.state$.pipe(map(x => {
      this.toDoList = x.toDos;
    }))
    .subscribe();

    this.store.dispatch(new GetToDoBeginAction());
  }

  createToDo(): void {
    const todo: ToDo = { Title: "aaaaa", IsCompleted: true };
    this.store.dispatch(new CreateToDoAction(todo));
  }
}
