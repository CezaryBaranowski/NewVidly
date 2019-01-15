import { Component, OnInit } from '@angular/core';
import { MovieService } from '../services/movie.service';
import { ToastyService } from 'ng2-toasty';

@Component({
  selector: 'app-movie-form',
  templateUrl: './movie-form.component.html',
  styleUrls: ['./movie-form.component.css']
})
export class MovieFormComponent implements OnInit {

  constructor(private customerService: MovieService,
    private toasty: ToastyService) { }

  movie: any = {};

  ngOnInit() {}

  submit() {
    console.log(this.movie);
  }
}
