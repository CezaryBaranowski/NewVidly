import { MovieService } from './../services/movie.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css']
})
export class MovieListComponent implements OnInit {

  constructor(private moviesService: MovieService, private router: Router) { }

  movies: any = [];

  ngOnInit() {

    this.moviesService.getMovies().subscribe(m => {this.movies = m;
      console.log(this.movies); });
  }
  more(m) {
    this.router.navigateByUrl('/movies/info/' + m.name);
  }

}
