import { GameComponent } from './components/game/game.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CreateGameComponent } from './components/create-game/create-game.component';

const routes: Routes = [
  { path: 'design/create-game', component: CreateGameComponent },
  { path: 'design/game', component: GameComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DevDesignRoutingModule { }
