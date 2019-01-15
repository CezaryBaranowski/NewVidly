import { filter } from 'rxjs/operators';
import { CustomerService } from './../services/customer.service';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ToastyService } from 'ng2-toasty';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class CustomerListComponent implements OnInit {

  customers: any = [];
  constructor(
    private customerService: CustomerService,
    private toasty: ToastyService) { }

  ngOnInit() {
    this.customerService.getCustomers().subscribe(c => {
      this.customers = c;
      console.log(this.customers);
    });
  }

  deleteCustomer(id) {
    if (confirm('Are you sure you want to delete this customer?')) {
      this.customerService.deleteCutomer(id).subscribe(r => {
        this.customers = this.customers.filter(item => item.id !== id);
        this.toasty.success({
          title: 'Success',
          msg: 'Customer was successfully removed.',
          theme: 'bootstrap',
          showClose: true,
          timeout: 5000
        });
      });

    }
}
}
