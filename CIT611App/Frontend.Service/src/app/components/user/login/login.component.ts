import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { APIService } from 'src/app/services/api.service';
import { TokenService } from 'src/app/token.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm :FormGroup;
  //loginForm: FormGroup={};
  constructor(private _formBuilder:FormBuilder,private _router:Router,private _apiService:APIService,private _tokenService:TokenService) {
    this.loginForm=this._formBuilder.group({
      UserName:[],
      Password:[]
    });
  }

  login(){
    console.log(this.loginForm.value);
    this._apiService.post("/User/Login",this.loginForm.value).subscribe(data => {
      console.log(data);
      if(data.IsSuccess){
        alert("IsSuccess");
        this._tokenService.setToken(data.Value['Token']);
        this._router.navigate(['/profile/index']);
      }else{
        alert(data.Error);
      }
    });

  }

}
