import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class MovieService {

  constructor(private http: HttpClient) { }

  getMovies() {
    return this.http.get('api/movies');
  }
}
