import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs/Observable';

@Injectable({
  providedIn: 'root'
})
export class MovieApiService {

  private omdb = 'https://www.omdbapi.com/?apikey=';
  constructor(private http: HttpClient) {}

    search(term: string): Observable<any> {
      return this.http.get(this.omdb + term + '&plot=full').pipe(
        map(response => {return response;
      }));
    }
}
