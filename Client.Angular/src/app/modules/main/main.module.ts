import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MainRoutingModule } from './main-routing.module';
import { FrontpageComponent } from './components/frontpage/frontpage.component';
import { SalespageComponent } from './components/salespage/salespage.component';
import { CheckoutComponent } from './components/checkout/checkout.component';

@NgModule({
  imports: [
    CommonModule,
    MainRoutingModule
  ],
  declarations: [FrontpageComponent, SalespageComponent, CheckoutComponent]
})
export class MainModule { }
