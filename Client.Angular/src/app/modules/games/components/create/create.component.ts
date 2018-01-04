import { environment } from '../../../../../environments/environment';
import { toBase64String } from '@angular/compiler/src/output/source_map';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Game } from '../../../../models/game';
import { GameService } from '../../../../services/game.service';

declare var $: any;
declare var Dropzone: any;

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class CreateComponent implements OnInit {

  gameForm: FormGroup;
  game: Game;
  picture: File;

  constructor(private fb: FormBuilder, private gameService: GameService) {
  }

  ngOnInit() {
    const createGameComponent = this;
    Dropzone.autoDiscover = false;
    this.createGameForm();

    $(document).ready(function () {
      $('#myDrop').dropzone({
        dragover: function (event: any) {
          if (event.target.classList.contains('dropzone')) {
            event.target.classList.add('shadow');
          }
        },
        dragleave: function (event: any) {
          event.target.classList.remove('shadow', 'dz-drag-hover');
        },
        uploadMultiple: false,
        maxFiles: 1,
        url: !environment.production ? 'http://localhost:5000/api/games' : '/api/games',
        thumbnailWidth: 175,
        thumbnailHeight: 175,
        previewTemplate: document.querySelector('#tpl').innerHTML,
        success: (file, response) => {
          createGameComponent.picture = file;
          console.log(file);
        },
        error: (file, response) => {
          createGameComponent.picture = file;
          console.log(file + ' ' + response);
        }
      });
      const element = document.querySelector('.dropzone');
      element.addEventListener('mouseover', function () {
        this.classList.add('shadow');
        element.addEventListener('mouseout', function () {
          this.classList.remove('shadow');
        });
      });
    });
  }

  // Initialize form with requirements
  createGameForm() {
    this.gameForm = this.fb.group({
      title: [null, Validators.required],
      shortDescription: [null, Validators.compose([Validators.required, Validators.minLength(30), Validators.maxLength(200)])],
      description: [null, Validators.required],
      price: [null, Validators.required],
      release: [null, Validators.required]
    });
  }

  addGame(game: Game): void {
    game.picture = this.picture;
    if (this.gameForm.valid && game.picture) {
      game.picture = this.picture;
      this.gameService.addGame(game).subscribe(
        res => {
          console.log(res);
          this.game = game;
          this.gameForm.reset();
        },
        err => {
          console.log(new Error(err.message));
        });
    } else {
      console.log('Validation error occured. Please check GameModule create.component.ts.');
      Object.keys(this.gameForm.controls).forEach(key => {
        this.gameForm.controls[key].markAsTouched();
        if (!game.picture) {
          document.getElementById('myDrop').style.borderColor = 'red';
        }
      });
    }
  }
}
