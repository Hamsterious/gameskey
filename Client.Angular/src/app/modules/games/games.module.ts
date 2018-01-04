import { HttpClientModule } from '@angular/common/http';
import { GameService } from '../../services/game.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GamesRoutingModule } from './games-routing.module';
import { CreateComponent } from './components/create/create.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    GamesRoutingModule,
  ],
  exports: [GamesRoutingModule],
  providers: [GameService],
  declarations: [CreateComponent]
})
export class GamesModule { }
