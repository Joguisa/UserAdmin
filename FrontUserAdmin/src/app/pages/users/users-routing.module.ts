import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListUsersComponent } from './components/list-users/list-users.component';


const routes: Routes = [
  {
    path: 'list-users',
    component: ListUsersComponent
  },
  {
    path: '',
    redirectTo: 'list-users',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }
