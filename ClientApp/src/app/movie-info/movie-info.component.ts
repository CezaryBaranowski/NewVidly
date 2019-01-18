import { MovieApiService } from './../services/movie-api.service';
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map} from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-movie-info',
  templateUrl: './movie-info.component.html',
  styleUrls: ['./movie-info.component.css']
})
export class MovieInfoComponent implements OnInit {


  message: string;
  movie: any = {};
  movieName: string;
  movieFound: boolean;
  moviePoster: string;
  info: any = {};
  constructor(private http: HttpClient, private moviesService: MovieApiService, private route: ActivatedRoute) { }

  ngOnInit() {

    this.movieName = this.route.snapshot.params['name'];
    this.searchMovies(this.movieName);
    console.log(this.movieName);
    console.log(this.movie);

}

searchMovies(term: string): void {
  this.moviesService.search(term).subscribe(res => {
    if (res.Response === 'True') {
      this.movie = res;
      console.log(res);
      if (this.movie.Poster !== 'N/A') {
        this.moviePoster = this.movie.Poster;
      } else {
        this.moviePoster = '';
      }
      this.movieFound = true;
    } else {
      this.movieFound = false;
      this.message = 'No movie was found that matched your search.';
    }
  });
  // console.log(term, this.movie);
}
}
