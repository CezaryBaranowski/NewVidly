import { filter } from 'rxjs/operators';
import { Component, OnInit } from '@angular/core';
import { RentalService } from '../services/rental.service';

@Component({
  selector: 'app-rental-list',
  templateUrl: './rental-list.component.html',
  styleUrls: ['./rental-list.component.css']
})
export class RentalListComponent implements OnInit {

  constructor(private rentalService: RentalService) { }

  rentals: any = [];

  ngOnInit() {

    this.rentalService.getRentals().subscribe(r => {this.rentals = r;
      console.log(this.rentals); });
  }

  finalizeRental(rental) {
    this.rentalService.removeRental(rental).subscribe(r => {});
    location.reload();
  }
}
