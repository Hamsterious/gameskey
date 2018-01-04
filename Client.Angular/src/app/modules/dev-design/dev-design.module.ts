import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DevDesignRoutingModule } from './dev-design-routing.module';
import { CreateGameComponent } from './components/create-game/create-game.component';
import { GameComponent } from './components/game/game.component';
import { OverviewSectionComponent } from './components/sections/overview-section/overview-section.component';
import { DetailsSectionComponent } from './components/sections/details-section/details-section.component';
import { MediaSectionComponent } from './components/sections/media-section/media-section.component';
import { ExtrasSectionComponent } from './components/sections/extras-section/extras-section.component';
import { CritiqueSectionComponent } from './components/sections/critique-section/critique-section.component';
import { PracticalSectionComponent } from './components/sections/practical-section/practical-section.component';
import { BuySectionComponent } from './components/sections/buy-section/buy-section.component';
import { RecommendedSectionComponent } from './components/sections/recommended-section/recommended-section.component';

@NgModule({
  imports: [
    CommonModule,
    DevDesignRoutingModule
  ],
  declarations: [
    CreateGameComponent,
    GameComponent,
    OverviewSectionComponent,
    DetailsSectionComponent,
    MediaSectionComponent,
    ExtrasSectionComponent,
    CritiqueSectionComponent,
    PracticalSectionComponent,
    BuySectionComponent,
    RecommendedSectionComponent
  ],
  exports: [GameComponent]
})
export class DevDesignModule { }
