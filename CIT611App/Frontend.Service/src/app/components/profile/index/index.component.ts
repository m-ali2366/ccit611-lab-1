import { Component } from '@angular/core';
import { APIService } from 'src/app/services/api.service';
import { Profile } from './profile.model';
import { ResponseViewModel } from 'src/app/models/response.model';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent {
  profiles:Profile[]=[];
  constructor(private _apiService:APIService)
  {
this._apiService.get('/profile/get')
 .subscribe((response:ResponseViewModel)=>
  {
    if(response.IsSuccess)
    this.profiles=response.Data['Items'] as Profile[];
  });
}

delete(index:number):void
{
  let profile=this.profiles[index];
  this._apiService.post(`/profile/delete`,profile)
  .subscribe((response:ResponseViewModel)=>{
    if(response.IsSuccess)
      this.profiles.splice(index,1);
  });



}

}
