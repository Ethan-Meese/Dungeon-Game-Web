import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Player {
  name: string;
  maxHealth: number;
  health: number;
  attackDamage: number;
  maxMana: number;
  mana: number;
  xP: number;
  level: number;
  isAlive: boolean;
}

export interface Enemy {
  name: string;
  health: number;
  attackDamage: number;
}

export interface Room {
  name: string;
  description: string;
  enemies: Enemy[];
}

export interface GameState {
  player: Player;
  currentRoom: Room;
  dungeonLevel: number;
  message: string;
  options: string[];
  isGameOver: boolean;
  justRested: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class GameService {
  private apiUrl = 'http://localhost:5216/api/game'; // adjust if your backend runs on a different port

  constructor(private http: HttpClient) {}

  /** Starts a new game */
  startGame(): Observable<GameState> {
    return this.http.post<GameState>(`${this.apiUrl}/start`, {});
  }

  /** Sends an action (e.g. "Attack", "Rest", "Continue Ahead") */
  sendAction(action: string): Observable<GameState> {
    return this.http.post<GameState>(`${this.apiUrl}/action`, { action });
  }

  /** (Optional) Get current game state without changing anything */
  getState(): Observable<GameState> {
    return this.http.get<GameState>(`${this.apiUrl}/state`);
  }
}
