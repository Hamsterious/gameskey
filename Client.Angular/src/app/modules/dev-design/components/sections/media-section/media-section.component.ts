import { Component, Input, OnInit } from '@angular/core';
import { Game } from '../../game/game.component';
@Component({
  selector: 'app-media-section',
  templateUrl: './media-section.component.html',
  styleUrls: ['./media-section.component.scss']
})
export class MediaSectionComponent implements OnInit {
  @Input()
  public game: Game;

  constructor() { }

  ngOnInit() {
  }
}
