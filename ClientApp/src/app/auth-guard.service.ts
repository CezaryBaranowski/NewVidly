import { AuthService } from './services/auth.service';
import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {

  constructor(protected auth: AuthService) {}

    canActivate() {
      if (this.auth.isAuthenticated()) {
        return true;
      }

      // tslint:disable-next-line:max-line-length
      // window.location.href = 'https://newvidly.eu.auth0.com/authorize?client_id=BMdXIV7Ayew0zcU1WZtP1FCNaVsFvm0Z&response_type=token%20id_token&redirect_uri=https%3A%2F%2Flocalhost%3A5001&scope=openid%20email%20profile&prompt=login&state=nA8Fvda2Eb8PvS6ht_v~uaBYzt_6eiam&nonce=Dclh8H4fV4G7XPc3iILJzpDjBUKUCR87&auth0Client=eyJuYW1lIjoiYXV0aDAuanMiLCJ2ZXJzaW9uIjoiOS45LjAifQ%3D%3D';

      return false;
    }
  }
