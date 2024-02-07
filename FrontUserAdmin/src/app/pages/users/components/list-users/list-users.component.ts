import { Component, OnInit } from '@angular/core';
import { UsersService } from '../../services/users.service';

@Component({
  selector: 'app-list-users',
  templateUrl: './list-users.component.html',
  styleUrls: ['./list-users.component.sass']
})
export class ListUsersComponent implements OnInit{

  constructor(
    private userService: UsersService
  ) { }

  ngOnInit(): void {
    this.userService.getUsers().subscribe((user) => {
      console.log(user);
    })
  }

  

}
