import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GeneralResponse } from 'src/app/shared/interfaces/general-response';
import { environment } from 'src/environments/environment';
import { AddUsers, EditUsers, Users } from '../interfaces/users';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  private urlBase: string = environment.API_URL;
  private apiUrl: string = this.urlBase + 'api';

  constructor(private http: HttpClient) {}

  getUsers() : Observable<GeneralResponse<Users[]>> {
    return this.http.get<GeneralResponse<Users[]>>(`${this.apiUrl}/User`);
  }

  getUser(id: number) : Observable<GeneralResponse<Users>> {
    return this.http.get<GeneralResponse<Users>>(`${this.apiUrl}/User/${id}`);
  }

  createUser(user: AddUsers) : Observable<GeneralResponse<AddUsers>> {
    return this.http.post<GeneralResponse<AddUsers>>(`${this.apiUrl}/User`, user);
  }

  updateUser(user: EditUsers) : Observable<GeneralResponse<EditUsers>> {
    return this.http.put<GeneralResponse<EditUsers>>(`${this.apiUrl}/User/${user.id}`, user);
  }

  deleteUser(id: number) : Observable<GeneralResponse<Users>> {
    return this.http.delete<GeneralResponse<Users>>(`${this.apiUrl}/User/${id}`);
  }

}
