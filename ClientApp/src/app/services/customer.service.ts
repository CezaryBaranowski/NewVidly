import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class CustomerService {

  constructor(private http: HttpClient) { }

    getCustomer(email): any {
    return this.http.get('api/customers/mail/' + email)
    .pipe();
  }

    getCustomers() {
    return this.http.get('api/customers')
    .pipe();
  }

    saveCustomer(customer) {
    return this.http.post('api/customers', customer)
    .pipe();
  }

    updateCustomer(customer) {
    return this.http.put('api/customers/mail/' + customer.email, customer)
    .pipe();
  }

    deleteCutomer(id: number) {
    return this.http.delete('api/customers' + '/' + id)
    .pipe();
  }
}
