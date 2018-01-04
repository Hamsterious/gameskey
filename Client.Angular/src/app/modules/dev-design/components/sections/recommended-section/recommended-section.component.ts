import { Component, Input, OnInit } from '@angular/core';
import { Game } from '../../game/game.component';
@Component({
  selector: 'app-recommended-section',
  templateUrl: './recommended-section.component.html',
  styleUrls: ['./recommended-section.component.scss']
})
export class RecommendedSectionComponent implements OnInit {
  @Input()
  public game: Game;

  constructor() { }

  ngOnInit() {
  }
}
