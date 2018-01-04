import { Component, Input, OnInit } from '@angular/core';
import { Game } from '../../game/game.component';

@Component({
  selector: 'app-buy-section',
  templateUrl: './buy-section.component.html',
  styleUrls: ['./buy-section.component.scss']
})
export class BuySectionComponent implements OnInit {

  @Input()
  public game: Game;

  constructor() { }

  ngOnInit() {
  }
}
