import { Component, OnInit } from '@angular/core';
import { GameService, type GameState } from '../../services/game.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-game',
  imports: [FormsModule, CommonModule],
  templateUrl: './game.component.html',
  styleUrl: './game.component.css',
  standalone: true
})
export class GameComponent implements OnInit{
state?: GameState;
loading = false;
errorMessage = '';

  constructor(private gameService: GameService) {}

  ngOnInit(): void {
    this.startGame();
  }

  startGame(): void{
    this.loading = true;
    this.gameService.startGame().subscribe({
      next: (data) => {
        this.state = data;
        this.loading = false;
      },
      error: (err) => {
        this.errorMessage = 'Failed to start game.';
        this.loading = false;
        console.error(err);
      }
    });
  }

  chooseAction(action: string) {
    this.loading = true;
    this.gameService.sendAction(action).subscribe({
      next: (data) => {
        this.state = data;
        this.loading = false;
      },
      error: (err) => {
        this.errorMessage = 'Action failed.';
        this.loading = false;
      }
    });
  }

  
}
