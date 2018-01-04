import { Component, Input, OnInit } from '@angular/core';
import { Game } from '../../game/game.component';
@Component({
  selector: 'app-extras-section',
  templateUrl: './extras-section.component.html',
  styleUrls: ['./extras-section.component.scss']
})
export class ExtrasSectionComponent implements OnInit {
  @Input()
  public game: Game;

  constructor() { }

  ngOnInit() {
  }
}
