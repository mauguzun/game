import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../environments/environment';
import { Observable } from 'rxjs';
import { BetAnswer } from 'src/models/BetAnswer';
import { User } from 'src/models/Money';
import { GameResult } from 'src/models/GameResult';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  private baseUrl: string = null;

  constructor(private http: HttpClient) {
    this.baseUrl = environment.apiUrl;
  }


  newGame(): any {
    return this.http.get<Observable<any>>(`${this.baseUrl}`);
  }
  bet(more: boolean): Observable<BetAnswer> {
    return this.http.get<BetAnswer>(`${this.baseUrl}/${more}`);
  }

  save(user: User): Observable<GameResult[]> {
    return this.http.post<GameResult[]>(`${this.baseUrl}`, user);
  }

  
}
