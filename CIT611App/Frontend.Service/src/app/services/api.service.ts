import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, catchError, map,throwError as observableThrowError } from 'rxjs';
import { TokenService } from '../token.service';
import { ResponseViewModel } from '../models/response.model';


@Injectable({providedIn: 'root'})
export class APIService {
  apiUrl: string="http://localhost:5124";
  constructor(private _httpClient:HttpClient,private tokenService:TokenService) { }

  private setHeaders(withFiles: boolean = false): HttpHeaders {
    let headersConfig = {
      'Content-Type': 'application/json',
      Accept: 'application/json',
      token: this.tokenService.getToken(),
    };

    let headersConfigWithImage = {
      Accept: 'application/json',
      token: this.tokenService.getToken(),
    };
    if (withFiles) return new HttpHeaders(headersConfigWithImage);
    else return new HttpHeaders(headersConfig);

  }
  private formatErrors(error: any) {
    if (error.status == 401) {
      //this._sharedService.logOut()
    } else if (error.status == 500) {
      //this._alertService.error('حدث خطأ من فضلك حاول لاحقاً');
    } else if (error.status == 404) {
      //this._alertService.error('حدث خطأ من فضلك حاول لاحقاً');
    }
    //this._logService.addToConsole(error);
    return observableThrowError(error);
  }
  get(path: string): Observable<ResponseViewModel> {
    return this._httpClient.get<ResponseViewModel>(`${this.apiUrl}${path}`, { headers: this.setHeaders() });
  }

  post(path: string,body:any): Observable<ResponseViewModel> {
    return this._httpClient.post<ResponseViewModel>(`${this.apiUrl}${path}`,body, { headers: this.setHeaders() });
  }

  put(path: string,body:any): Observable<ResponseViewModel> {
    return this._httpClient.put<ResponseViewModel>(`${this.apiUrl}${path}`,body, { headers: this.setHeaders() });
  }


  delete(path: string): Observable<ResponseViewModel> {
    return this._httpClient.delete<ResponseViewModel>(`${this.apiUrl}${path}`, { headers: this.setHeaders() });
  }
}
