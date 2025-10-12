import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class GameService {
  private apiUrl = 'http://localhost:5216/api/game';

  constructor(private http: HttpClient) {}

  startGame(): Observable<any> {
    return this.http.get(`${this.apiUrl}/start`);
  }

  sendChoice(choice: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/choose`, choice);
  }
}
