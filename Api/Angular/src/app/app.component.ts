import { Component } from '@angular/core';
import { BetAnswer } from 'src/models/BetAnswer';
import { GameResult } from 'src/models/GameResult';
import { User } from 'src/models/Money';
import { Status } from 'src/Models/Status';
import { GameService } from './game.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})

export class AppComponent {

  public gameStatus :BetAnswer  = new BetAnswer();
  public user: User = new User();
  public loader = false;
  public bestScores: GameResult[] = null;


  constructor(public gameService: GameService) { }

  start() {
    this.loader = true;
    this.gameService.newGame().subscribe(result => {
      this.gameStatus.Status = Status.Started;
      this.gameStatus.Score = 0;
      this.bestScores = null;
    }, err => {
      alert(err.error);
    }, () => { this.loader = false; });
  }

  bet(more: boolean) {
    this.loader = true;
    this.gameService.bet(more).subscribe((result: BetAnswer) => {

      this.gameStatus = result;
     

    }, err => {
      alert(err.error);
    }, () => { this.loader = false; });
  }



  save() {
    this.loader = true;
    this.gameService.save(this.user).subscribe((bestScores: GameResult[]) => {
      this.bestScores = bestScores;
      this.gameStatus.Status = Status.Stopped;
    }, err => {
      alert(err.error);
    },
      () => { this.loader = false; });
  }

}
