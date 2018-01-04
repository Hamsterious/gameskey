import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-create-game',
  templateUrl: './create-game.component.html',
  styleUrls: ['./create-game.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class CreateGameComponent implements OnInit {

  public currentStep = 0;
  public steps: any[];

  constructor() { }

  ngOnInit() {
    this.steps = this.getSteps();
    this.setStepTo('next');
  }

  public setStepTo(step: string): void {
    if (step === 'next') {
      if (this.currentStep < this.steps.length) {
        this.steps[this.currentStep].active = 'active';
        this.currentStep++;
      }
    } else if (step === 'previous') {
      if (this.currentStep > 1) {
        this.currentStep--;
        this.steps[this.currentStep].active = '';
      }
    }
  }

  public getSteps(): any {
    return this.steps = [
      {
        id: 1,
        active: ''
      },
      {
        id: 2,
        active: ''
      },
      {
        id: 2,
        active: ''
      }
    ];
  }
}
