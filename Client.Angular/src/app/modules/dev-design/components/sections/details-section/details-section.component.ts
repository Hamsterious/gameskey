import { Component, Input, OnInit } from '@angular/core';
import { Game } from '../../game/game.component';
@Component({
  selector: 'app-details-section',
  templateUrl: './details-section.component.html',
  styleUrls: ['./details-section.component.scss']
})
export class DetailsSectionComponent implements OnInit {
  @Input()
  public game: Game;

  constructor() { }

  ngOnInit() {
  }
}
