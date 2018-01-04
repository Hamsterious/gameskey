import { environment } from '../../../../../environments/environment';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';

import { Game } from '../../../../models/game';
import { GameService } from '../../../../services/game.service';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-frontpage',
  templateUrl: './frontpage.component.html',
  styleUrls: ['./frontpage.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class FrontpageComponent implements OnInit {
  pictureEndpoint: string;
  games: Observable<Game[]>;
  private loading = false;

  constructor(private gameService: GameService) {
    this.pictureEndpoint = !environment.production ? 'http://localhost:5000/api/pictures' : '/api/pictures';
  }

  ngOnInit() {
    this.getGames();
  }

  getGames(): void {
    this.loading = true;
    this.games = this.gameService.getGames();
    Observable.create(new Game());
    this.loading = false;
  }
}
