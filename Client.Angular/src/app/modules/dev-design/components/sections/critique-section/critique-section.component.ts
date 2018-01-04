import { Component, Input, OnInit } from '@angular/core';
import { Game } from '../../game/game.component';
@Component({
  selector: 'app-critique-section',
  templateUrl: './critique-section.component.html',
  styleUrls: ['./critique-section.component.scss']
})
export class CritiqueSectionComponent implements OnInit {
  @Input()
  public game: Game;

  constructor() { }

  ngOnInit() {
  }
}
