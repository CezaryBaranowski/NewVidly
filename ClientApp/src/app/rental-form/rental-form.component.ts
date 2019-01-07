import { MovieService } from './../services/movie.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-rental-form',
  templateUrl: './rental-form.component.html',
  styleUrls: ['./rental-form.component.css']
})
export class RentalFormComponent implements OnInit {

  movies;
  selectedMovie: any;
  constructor(private movieService: MovieService) { }

  ngOnInit() {
    this.movieService.getMovies().subscribe(movies => {
    this.movies = movies;
    console.log('MOVIES', this.movies);
    });
  }

  onTitleChange() {
    console.log('Siemka');
    console.log('MovieTitle: ', this.selectedMovie);
  }

}