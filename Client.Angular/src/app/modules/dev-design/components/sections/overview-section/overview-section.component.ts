import { Component, Input, OnInit } from '@angular/core';
import { Game } from '../../game/game.component';

@Component({
  selector: 'app-overview-section',
  templateUrl: './overview-section.component.html',
  styleUrls: ['./overview-section.component.scss']
})
export class OverviewSectionComponent implements OnInit {
  @Input()
  public game: Game;

  constructor() { }

  ngOnInit() {
  }
}
