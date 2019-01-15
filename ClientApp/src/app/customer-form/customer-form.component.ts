import { Component, OnInit } from '@angular/core';
import {NgbDateStruct, NgbCalendar} from '@ng-bootstrap/ng-bootstrap';
import { CustomerService } from '../services/customer.service';
import { ToastyService } from 'ng2-toasty';

@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.css']
})
export class CustomerFormComponent implements OnInit {

  BirthdayDate: any;
  customer: {};

  constructor(
    private customerService: CustomerService,
    private toasty: ToastyService) { }

  ngOnInit() {
  }

}
