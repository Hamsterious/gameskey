import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class SidebarComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  public openNav(): void {
    document.getElementById('sidebar').style.width = '250px';
  }

  public closeNav(): void {
    document.getElementById('sidebar').style.width = '0';
  }
}
