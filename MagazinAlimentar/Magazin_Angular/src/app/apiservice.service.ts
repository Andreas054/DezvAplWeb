import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})

export class ApiserviceService {
  private readonly apiUrl = 'https://localhost:7293/api/';

  constructor(private readonly httpClient: HttpClient) { }

  getAll<T>(path: string, params = {}): Observable<any>{
    return this.httpClient.get<T>(`${this.apiUrl}${path}`, {params});
  }
}