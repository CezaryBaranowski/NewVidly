import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class CustomerService {

  constructor(private http: HttpClient) { }

    getCustomers() {
    return this.http.get('api/customers')
    .pipe();
  }

  deleteCutomer(id: number) {
    return this.http.delete('api/customers' + '/' + id)
    .pipe();
  }
}
