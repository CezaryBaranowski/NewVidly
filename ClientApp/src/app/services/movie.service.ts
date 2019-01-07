import { Injectable } from '@angular/core';
import { map, filter, switchMap } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class MovieService {

  constructor(private http: HttpClient) { }

  getMovies() {
    return this.http.get('api/movies')
    .pipe();
  }
}
