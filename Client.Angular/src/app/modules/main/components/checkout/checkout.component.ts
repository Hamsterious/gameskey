import { environment } from '../../../../../environments/environment';
import { Game } from '../../../../models/game';
import { Observable } from 'rxjs/Observable';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class CheckoutComponent implements OnInit {
  basket: Observable<Game[]>;
  pictureEndpoint: string;
  totalPrice = 0;
  constructor() {
    this.pictureEndpoint = !environment.production ? 'http://localhost:5000/api/pictures' : '/api/pictures';
  }

  ngOnInit() {
    // Mock data
    this.basket = new Observable(observer => {
      observer.next(new Array<Game>(
        new Game({ id: 1, title: 'Witcher 3', price: 15, pictureId: 6 }),
        new Game({ id: 2, title: 'Dota 2', price: 30, pictureId: 6 }),
        new Game({ id: 3, title: 'Subnautica', price: 45, pictureId: 6 })
        // new Game({ id: 4, title: 'GTA V' }),
        // new Game({ id: 5, title: 'Fifa 18' }),
        // new Game({ id: 6, title: 'Football Manager 18' }),
        // new Game({ id: 7, title: 'Warcraft 3' }),
        // new Game({ id: 8, title: 'World of Warcraft' }),
        // new Game({ id: 9, title: 'Battlerite' })
      ));
    });
    this.getTotalPrice();
  }
  getTotalPrice() {
    this.basket.forEach(game => game.filter(x => this.totalPrice += x.price));
  }

}
