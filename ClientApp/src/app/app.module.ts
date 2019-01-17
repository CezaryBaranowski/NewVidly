import { AuthGuardService } from './auth-guard.service';
import { AuthService } from './services/auth.service';
import { MovieService } from './services/movie.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ToastyModule } from 'ng2-toasty';
import { JwtModule } from '@auth0/angular-jwt';

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
import { AdminAuthGuardService } from './admin-auth-guard.service';
import { AUTH_PROVIDERS } from 'angular2-jwt/angular2-jwt';
import { LogoutComponent } from './logout/logout.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LogoutComponent,
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
    JwtModule.forRoot({
      config: {
        tokenGetter: () => {
          return localStorage.getItem('token'); },
        whitelistedDomains: ['https://localhost:5001']
      }
    }),
    NgbModule,
    ToastyModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'logout', component: LogoutComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'customers', component: CustomerListComponent, canActivate: [AdminAuthGuardService] },
      { path: 'customers/new', component: CustomerFormComponent },
      { path: 'movies', component: MovieListComponent },
      { path: 'movies/new', component: MovieFormComponent, canActivate: [AdminAuthGuardService] },
      { path: 'rentals', component: RentalListComponent, canActivate: [AdminAuthGuardService] },
      { path: 'rentals/new', component: RentalFormComponent }
    ])
  ],
  providers: [
    MovieService,
    CustomerService,
    RentalService,
    AuthService,
    AUTH_PROVIDERS,
    AuthGuardService,
    AdminAuthGuardService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
