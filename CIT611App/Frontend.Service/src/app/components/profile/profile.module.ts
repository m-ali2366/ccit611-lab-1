import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IndexComponent } from './index/index.component';
import { CreateComponent } from './create/create.component';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

const routes: Routes = [
  {path:'index',component:IndexComponent},
  {path:'create',component:CreateComponent},
  {path:'',component:IndexComponent}
];

@NgModule({
  declarations: [
    IndexComponent,
    CreateComponent
  ],
  imports: [
    CommonModule,FormsModule,ReactiveFormsModule,RouterModule.forChild(routes)
  ]
})
export class ProfileModule { }
