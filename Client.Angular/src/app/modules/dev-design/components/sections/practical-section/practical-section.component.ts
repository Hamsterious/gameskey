import { Component, Input, OnInit } from '@angular/core';
import { Game } from '../../game/game.component';

@Component({
  selector: 'app-practical-section',
  templateUrl: './practical-section.component.html',
  styleUrls: ['./practical-section.component.scss']
})
export class PracticalSectionComponent implements OnInit {
  @Input()
  public game: Game;

  constructor() { }

  ngOnInit() {
  }
}
