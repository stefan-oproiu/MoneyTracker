import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {
  API_BASE_URL,
  deserializeTimePeriod,
  TimePeriodDTO,
  TimePeriod,
} from '@models';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

const API_ME = `${API_BASE_URL}/me`;

@Injectable({ providedIn: 'root' })
export class MeService {
  constructor(private http: HttpClient) {}

  checkUser(): Observable<any> {
    return this.http.post(`${API_ME}/check`, {});
  }

  getTimePeriods(): Observable<TimePeriod[]> {
    return this.http
      .get<TimePeriodDTO[]>(`${API_ME}/time-periods`)
      .pipe(map((dtos) => dtos.map(deserializeTimePeriod)));
  }
}
