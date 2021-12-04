import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import ToDo from '../dtos/todo';

@Injectable({
  providedIn: 'root'
})
export class WorkplaceService {
  private ApiURL: string = 'https://localhost:44308/api/ToDo';

  constructor(private http: HttpClient) {}

  getToDos() {
    return this.http.get<ToDo[]>(this.ApiURL);
  }

  createToDos(todo: ToDo) {
    return this.http.post<ToDo>(this.ApiURL, todo);
  }
}
