import { AuthGuardService } from './auth-guard.service';
import { Injectable } from '@angular/core';
import { AuthService } from './services/auth.service';
import { CanActivate } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AdminAuthGuardService extends AuthGuardService {

  constructor(auth: AuthService) {
    super(auth);
  }

  canActivate() {
    let isAuthenticated = super.canActivate();
    return isAuthenticated ? this.auth.isInRole('Admin') : false;
    }
}
