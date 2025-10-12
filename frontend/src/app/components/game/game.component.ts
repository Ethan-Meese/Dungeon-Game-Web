import { Component } from '@angular/core';
import { GameService } from '../../services/game.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-game',
  imports: [FormsModule, CommonModule],
  templateUrl: './game.component.html',
  styleUrl: './game.component.css',
  standalone: true
})
export class GameComponent {
  state: string  = '';
  health: number = 100;
  choice: string = '';

  constructor(private gameService: GameService) {}

  startGame() {
    this.gameService.startGame().subscribe((data) => {
      this.state = data.state;
      this.health = data.health;
    });
  }

  makeChoice() {
    this.gameService.sendChoice(this.choice).subscribe((data) => {
      this.state = data.state;
      this.health = data.health;
      this.choice = '';
    });
  }
  
}
