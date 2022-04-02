import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { API_BASE_URL, User } from '@models';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class UsersService {
  constructor(private http: HttpClient) {}

  checkUser(): Observable<any> {
    return this.http.post(`${API_BASE_URL}/users/check`, {});
  }

  getAllUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${API_BASE_URL}/users`);
  }
}
