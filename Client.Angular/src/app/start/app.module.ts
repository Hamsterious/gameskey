import { LayoutModule } from '../modules/layout/layout.module';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { DevDesignModule } from '../modules/dev-design/dev-design.module';
import { GamesModule } from '../modules/games/games.module';
import { AppComponent } from './app.component';

import { MainModule } from '../modules/main/main.module';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    LayoutModule,
    GamesModule,
    DevDesignModule,
    MainModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
