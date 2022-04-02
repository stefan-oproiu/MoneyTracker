import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { API_BASE_URL, MoneyCategory } from '@models';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  constructor(private http: HttpClient) {}

  getCategories(): Observable<MoneyCategory[]> {
    return this.http.get<MoneyCategory[]>(`${API_BASE_URL}/money-categories`);
  }
}
