import { Injectable } from '@angular/core';
import { TokenService } from '../token.service';

@Injectable({providedIn: 'root'})
export class UserService {
  constructor(private _tokenService:TokenService) { }

  isAuthenticated(): boolean {
    return this._tokenService.isAuthenticated();
  }

}
