import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, MaxValidator, Validators } from '@angular/forms';
import { APIService } from 'src/app/services/api.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent {
  form :FormGroup;
  constructor(private _apiService:APIService,private _formBuilder:FormBuilder){
    this.form=this._formBuilder.group({
      FirstName:['',[Validators.required]],
      LastName:['',[Validators.required]],
      Age:['10',[Validators.required]]

    });
  }

  save(){
    console.log(this.form.value);
    this._apiService.post("/Profile/Post",this.form.value)
    .subscribe(data => {
      console.log(data);
      if(data.IsSuccess)
        {
          alert('You successfully create new profile');
        }
    });
  }



}
