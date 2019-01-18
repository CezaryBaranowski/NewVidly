import { Customer } from './../Models/customer';
import { AuthService } from './../services/auth.service';
import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../services/customer.service';
import { Router } from '@angular/router';
import { ToastyService } from 'ng2-toasty';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  public customer: Customer;
  wasInDb: boolean;

  constructor(
    private auth: AuthService,
    private customerService: CustomerService,
    private router: Router,
    private toastyService: ToastyService) {
    // this.customer.email = auth.email;
    this.initCustomer();
   }

  ngOnInit() {
  }
  public hasFullCredentials (): boolean {

    return this.customer.name ? true : false;
  }

  initCustomer() {
    this.customer = new Customer();
    this.customer.name = '';
    this.customer.email = this.auth.email;

    this.customerService.getCustomer(this.customer.email).subscribe(c => {
      if (c != null) {
      this.wasInDb = true;
      this.customer = c;
      } else { this.wasInDb = false; }

      if (this.customer.birthdayDate && this.customer.birthdayDate.length > 0) {
      this.customer.birthdayDate = this.customer.birthdayDate.split(' ')[0];
      } else {this.customer.birthdayDate = ''; }

      if (this.customer.name.length < 3) {
        this.customer.name = '';
      }
      this.customer.email = this.auth.email;
      console.log(this.customer); });
  }

  submit() {
    let result$ = !this.wasInDb ? this.customerService.saveCustomer(this.customer) : this.customerService.updateCustomer(this.customer);

    result$.subscribe(customer => {
      this.toastyService.success({
        title: 'Success',
        msg: 'User was sucessfully saved.',
        theme: 'bootstrap',
        showClose: true,
        timeout: 5000
      });
      this.router.navigate(['']);
    });
  }

}
