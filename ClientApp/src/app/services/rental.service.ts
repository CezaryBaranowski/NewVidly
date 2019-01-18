import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RentalService {

  constructor(private http: HttpClient) { }

  getRentals() {
    return this.http.get('api/rentals')
    .pipe();
  }

  addRental(rental) {
    return this.http.post('api/rentals', rental)
    .pipe();
  }

  removeRental(rental) {
    return this.http.put('api/rentals/' + rental.id, rental)
    .pipe();
  }
}
