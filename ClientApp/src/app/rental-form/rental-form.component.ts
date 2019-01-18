import { ToastyService } from 'ng2-toasty';
import { CustomerService } from './../services/customer.service';
import { AuthService } from './../services/auth.service';
import { RentalService } from './../services/rental.service';
import { MovieService } from './../services/movie.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-rental-form',
  templateUrl: './rental-form.component.html',
  styleUrls: ['./rental-form.component.css']
})
export class RentalFormComponent implements OnInit {

  movies;
  selectedMovie: any = {};
  customerInfo: any = {};
  rentalDto: any = {};

  constructor(
    private movieService: MovieService,
    private rentalService: RentalService,
    private auth: AuthService,
    private customerService: CustomerService,
    private toasty: ToastyService) {

   }

  ngOnInit() {
    this.movieService.getMovies().subscribe(movies => {
    this.movies = movies;

    let mail = this.auth.email;
    this.customerService.getCustomer(mail).subscribe(c => {this.customerInfo = c;
       },
      err => {
      this.toasty.error({
        title: 'Error',
        msg: 'Fill user info first',
        theme: 'bootstrap',
        showClose: true,
        timeout: 5000
      });
    });
    console.log('MOVIES', this.movies);
    });

  }

  submit() {
    this.rentalDto.movieId = this.selectedMovie;
    // this.rentalDto.movieName = this.selectedMovie.name;
    this.rentalDto.customerId = this.customerInfo.id;
    this.rentalDto.customername = this.customerInfo.name;
    this.rentalService.addRental(this.rentalDto).subscribe(r => {console.log(r);
      this.toasty.success({
        title: 'Success',
        msg: 'Rental was sucessfully saved.',
        theme: 'bootstrap',
        showClose: true,
        timeout: 5000
      }); },
    err => {
      this.toasty.error({
        title: 'Error',
        msg: 'Submit problem',
        theme: 'bootstrap',
        showClose: true,
        timeout: 5000
      });
    } );
  }

  onTitleChange() {
    console.log('MovieTitle: ', this.selectedMovie);
  }

}
