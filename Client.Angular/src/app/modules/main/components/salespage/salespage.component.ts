import { environment } from '../../../../../environments/environment';
import { ActivatedRoute } from '@angular/router';
import { Game } from '../../../../models/game';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { GameService } from '../../../../services/game.service';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-salespage',
  templateUrl: './salespage.component.html',
  styleUrls: ['./salespage.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class SalespageComponent implements OnInit {
  game: Observable<Game>;
  pictureEndpoint: string;
  constructor(private gameService: GameService, private route: ActivatedRoute) {
    this.pictureEndpoint = !environment.production ? 'http://localhost:5000/api/pictures' : '/api/pictures';
  }

  ngOnInit() {
    console.log('running ngOnInit');
    this.route.params.subscribe(params => this.getGame(params['id']));
    // Mock data
    // this.game = new Observable(observable => {
    //   observable.next(new Game({
    //     title: 'Dota 2',
    //     shortDescription: 'Every day, millions of players worldwide enter battle as one of over a hundred Dota heroes.'
    //   }));
    // });
  }

  getGame(id: number): void {
    console.log('requesting game with id ' + id);
    this.game = this.gameService.getGame(id);
    console.log(this.game);
  }
}
