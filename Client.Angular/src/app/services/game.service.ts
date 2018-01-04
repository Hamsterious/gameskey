import { environment } from '../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Game } from '../models/game';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Injectable()
export class GameService {
  gameUrl;
  results: any[];

  constructor(private http: HttpClient) {
    if (!environment.production) {
      this.gameUrl = 'http://localhost:5000/api/games';
      console.log('This is local');
      console.log(this.gameUrl);
    } else {
      this.gameUrl = '/api/games';
      console.log('This is production');
      console.log(this.gameUrl);
    }
  }

  addGame(game: Game): Observable<Game> {

    const picture: File = game.picture;

    const collection: FormData = new FormData();

    const viewModel = JSON.stringify({
      'title': game.title,
      'shortDescription': game.shortDescription,
      'description': game.description,
      'price': game.price,
      'release': game.release
    });
    collection.append('viewModel', viewModel);
    collection.append('picture', picture);
    return this.http.post<Game>(this.gameUrl, collection);
  }

  getGame(id: number): Observable<Game> {
    return this.http.get<Game>(this.gameUrl + '/' + id);
  }

  getGames(): Observable<Game[]> {
    return this.http.get<Game[]>(this.gameUrl);
  }
}
