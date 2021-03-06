import { tokenNotExpired, JwtHelper } from 'angular2-jwt';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { AUTH_CONFIG } from './auth0-variables';
import { filter } from 'rxjs/operators';
import * as auth0 from 'auth0-js';

@Injectable()
export class AuthService {

  private _idToken: string;
  private _accessToken: string;
  private _expiresAt: number;
  userProfile: any;
  private roles: string[] = [];

  auth0 = new auth0.WebAuth({
    clientID: AUTH_CONFIG.clientID,
    domain: AUTH_CONFIG.domain,
    responseType: 'token id_token',
    redirectUri: AUTH_CONFIG.callbackURL,
    scope: 'openid email profile'
  });

  constructor(public router: Router) {
    this._idToken = '';
    this._accessToken = '';
    this._expiresAt = 0;
    this.userProfile = JSON.parse(localStorage.getItem('profile'));

    let token = localStorage.getItem('token');
    if (token) {
      let jwtHelper = new JwtHelper();
      let decodedToken = jwtHelper.decodeToken(token);
      this.roles = decodedToken[AUTH_CONFIG.rolesClaim];
    }
  }

  get accessToken(): string {
    return this._accessToken;
  }

  get idToken(): string {
    return this._idToken;
  }

  get email(): string {
    let token = localStorage.getItem('token');
    let jwtHelper = new JwtHelper();
       let decodedToken = jwtHelper.decodeToken(token);
       return decodedToken['email'];
  }

  public login(): void {
    this.auth0.authorize({prompt: 'login'});
  }

  public handleAuthentication(): void {
    this.auth0.parseHash((err, authResult) => {

      if (authResult && authResult.accessToken && authResult.idToken) {
        window.location.hash = '';
        this.localLogin(authResult);

        // this.getProfile((err, profile) => {
        //   this.userProfile = profile;
        //   });

        console.log(authResult);
        localStorage.setItem('token', authResult.idToken);

       let jwtHelper = new JwtHelper();
       let decodedToken = jwtHelper.decodeToken(authResult.idToken);
       this.roles = decodedToken[AUTH_CONFIG.rolesClaim];
       console.log('roles: ' + this.roles);
       console.log('dc :' + decodedToken);
       console.log('claims :' + AUTH_CONFIG.rolesClaim);

        this.router.navigate(['/user']);
      } else if (err) {
        this.router.navigate(['/']);
        console.log(err);
        alert(`Error: ${err.error}. Check the console for further details.`);
      }
    });
  }

  private localLogin(authResult): void {
    // Set isLoggedIn flag in localStorage
    localStorage.setItem('isLoggedIn', 'true');
    // Set the time that the access token will expire at
    const expiresAt = (authResult.expiresIn * 1000) + new Date().getTime();
    this._accessToken = authResult.accessToken;
    this._idToken = authResult.idToken;
    this._expiresAt = expiresAt;
  }

  public getProfile(cb): void {
    if (!this._accessToken) {
      throw new Error('Access token must exist to fetch profile');
    }

    const self = this;
    this.auth0.client.userInfo(this._accessToken, (err, profile) => {
      if (profile) {
        self.userProfile = profile;
        localStorage.setItem('profile', JSON.stringify(profile));
      }
      cb(err, profile);
    });
    console.log(this.userProfile);
  }

  public isInRole(roleName: string) {
    if (this.roles === undefined || this.roles.length < 1) {
    return false;
    }
    return this.roles.indexOf(roleName) > -1;
  }

  public renewTokens(): void {
    this.auth0.checkSession({}, (err, authResult) => {
      if (authResult && authResult.accessToken && authResult.idToken) {
        this.localLogin(authResult);
      } else if (err) {
        alert(`Could not get a new token (${err.error}: ${err.error_description}).`);
        this.logout();
      }
    });
  }

  public logout(): void {
    // Remove tokens and expiry time
    this._accessToken = '';
    this._idToken = '';
    this._expiresAt = 0;
    // Remove isLoggedIn flag from localStorage
    localStorage.removeItem('token');
    localStorage.removeItem('isLoggedIn');
    localStorage.removeItem('profile');
    localStorage.removeItem('userToken');
    this.userProfile = null;
    // Go back to the home route
    this.router.navigate(['/logout']);
  }

  public isAuthenticated(): boolean {
    // Check whether the current time is past the
    // access token's expiry time
    return tokenNotExpired('token');
    // return new Date().getTime() < this._expiresAt;
  }

}
