import { Injectable,Inject } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class TokenService {
  TOKEN_STORAGE_NAME:string="token";
  setToken(token: string) {
    localStorage.setItem(this.TOKEN_STORAGE_NAME, token);
  }

  getToken(): string {
    const token = localStorage.getItem(this.TOKEN_STORAGE_NAME);
    return token || '';
  }

  hasAccessToken(): boolean {
    const token = this.getToken();
    return token.length > 0;
  }

  removeToken() {
    localStorage.removeItem(this.TOKEN_STORAGE_NAME);
  }




  clearUserData() {
    this.removeToken();
  }

  isAuthenticated(): boolean {
    return this.hasAccessToken();
  }

  // isAuthorized(role: ApplicationRole): boolean {
  //   const userRole = +this.localStroageInject.getUserRole();
  //   return !isNaN(userRole) && userRole === role;
  // }



}
