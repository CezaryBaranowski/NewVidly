import { MovieService } from './services/movie.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ToastyModule } from 'ng2-toasty';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { RentalFormComponent } from './rental-form/rental-form.component';
import { RentalListComponent } from './rental-list/rental-list.component';
import { MovieListComponent } from './movie-list/movie-list.component';
import { MovieFormComponent } from './movie-form/movie-form.component';
import { CustomerFormComponent } from './customer-form/customer-form.component';
import { CustomerListComponent } from './customer-list/customer-list.component';
import { MovieViewComponent } from './movie-view/movie-view.component';
import { CustomerService } from './services/customer.service';
import { RentalService } from './services/rental.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    RentalFormComponent,
    RentalListComponent,
    MovieListComponent,
    MovieFormComponent,
    CustomerFormComponent,
    CustomerListComponent,
    MovieViewComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgbModule,
    ToastyModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'customers', component: CustomerListComponent },
      { path: 'customers/new', component: CustomerFormComponent },
      { path: 'movies', component: MovieListComponent },
      { path: 'movies/new', component: MovieFormComponent },
      { path: 'rentals', component: RentalListComponent },
      { path: 'rentals/new', component: RentalFormComponent }
    ])
  ],
  providers: [
    MovieService,
    CustomerService,
    RentalService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
