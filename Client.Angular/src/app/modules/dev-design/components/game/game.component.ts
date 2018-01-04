import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class GameComponent implements OnInit {

  public game: Game;
  public sections: Section[] = [];

  constructor() { }

  ngOnInit() {
    this.getGame();
    this.getGammeSections(this.game.id);
  }

  public getGammeSections(gameId: number) {
    this.sections.push(new Section({
      id: 1,
      gameId: gameId,
      backgroundColor: 'white',
      type: 1
    }));

    this.sections.push(new Section({
      id: 2,
      gameId: gameId,
      backgroundColor: 'grey',
      type: 2
    }));

    this.sections.push(new Section({
      id: 3,
      gameId: gameId,
      backgroundColor: 'white',
      type: 3
    }));

    // Ensures the sections are sorted from type 1 -> 2 -> 3 etc.
    this.sections.sort((a: Section, b: Section) => {
      return a.type - b.type;
    });
  }

  public getGame() {
    this.game = new Game({
      id: 4,
      title: `Ori and the blind forest`,
      coverPictureUrl: `http://localhost:5000/api/pictures/1`,
      // tslint:disable-next-line:max-line-length
      gameSummary: `Ori and the Blind Forest" tells the tale of a young orphan destined for heroics, through a visually stunning action-platformer crafted by Moon Studios for PC.`,
      price: 30,
      priceValuta: `Euro`,
      salesPrice: 0,
      releaseDate: new Date(`2017-10-10`),
      languages: [`English`, `German`],
      multiplayer: `No`,
      vrSuport: `No`,
      ageRating: 12,
      faq: [
        `Q: Is it fun? A: Yes it is.`,
        `Q: Is it difficult? A: Surprisingly so!`,
        `Q: How long does it take to complete? A: 10hours roughly.`
      ],
      systemRequirements: `
        OS: Windows 7
        Processor: Intel Core i5 2300 or AMD FX6120
        Memory: 4 GB RAM
        Graphics: GeForce GTX 550 Ti or Radeon HD 6770
        DirectX: Version 11
        Storage: 8 GB available space
      `,
      hardwareSupport: `
        Controller
        Mouse and Keyboard
      `,
      externalLinks: [
        `https://www.reddit.com/r/OriAndTheBlindForest/`,
        ``
      ],
      publisher: {
        name: `Microsoft Studios`,
        site: `https://www.microsoftstudios.com/`,
      },
      developer: {
        name: `Moon Studios`,
        site: `https://www.orithegame.com/moon-studios/`
      },
      platforms: [
        { name: `Steam` },
        { name: `Windows` },
        { name: `Xbox` }
      ],
      regions: [
        { name: `NTSC-J (Japan and Asia)` },
        { name: `NTSC-U (North and Sourth America)` },
        { name: `NTSC-C (China)` },
        { name: `PAL (Europe, New Zealand, Australia)` }
      ],
      genres: [
        { name: `Adventure` },
        { name: `2D` }
      ],
      tags: [
        { name: `Single Player` },
        { name: `Side Scrolling` },
        { name: `Adventure` },
        { name: `GOTY` }
      ],
      // tslint:disable-next-line:max-line-length
      history: `The forest of Nibel is dying. After a powerful storm sets a series of devastating events in motion, an unlikely hero must journey to find his courage and confront a dark nemesis to save his home. “Ori and the Blind Forest” tells the tale of a young orphan destined for heroics, through a visually stunning action-platformer crafted by Moon Studios for PC. Featuring hand-painted artwork, meticulously animated character performance, and a fully orchestrated score, “Ori and the Blind Forest” explores a deeply emotional story about love and sacrifice, and the hope that exists in us all.`,
      world: `A beautiful world in the form of a vast forest encompassing mountains, rivers, tundras, and more.`,
      features: `
        Experience a lush, beautiful 2D world.
        Choose your playing style by leveling up in the 3 skill trees.
        Pixel Perfect control allows you to master Ori to perfection.
        A story filled with sorrow, strife, and hope.
      `,
      characters: [
        {
          name: `Ori`,
          // tslint:disable-next-line:max-line-length
          pictureUrl: `https://cdna.artstation.com/p/assets/images/images/004/203/896/large/elisavet-theodosiou-ori-and-the-blind-forest-small.jpg?1481300231`,
        },
        {
          name: `Naru`,
          pictureUrl: `https://img00.deviantart.net/8965/i/2016/336/0/2/naru___ori_and_the_blind_forest_by_eloel-daqbild.jpg`
        },
        {
          name: `Gumo`,
          pictureUrl: `https://vignette.wikia.nocookie.net/oriandtheblindforest/images/6/65/Gumo.png/revision/latest?cb=20150313171641`
        },
        {
          name: `Kuro`,
          pictureUrl: `https://www.epicureancure.com/wp/wp-content/uploads/2016/08/ori-hero-final.jpg`
        }
      ],
      enemies: [{}],
      mechanics: [{}],
      videos: [{}],
      pictures: [{}],
      news: [{}],
      editions: [{}],
      dlcs: ``,
      bundles: ``,
      officialReviews: [],
      youtubeReviews: [],
      buyerReviews: [],
      twitchStreams: [],
      pros: [],
      cons: [],
      metacriticTag: ``,
    });
  }
}

class Section {
  public id: number;
  public gameId: number;
  public backgroundColor: string;

  /**
   * Backend type is enum. Number equeals to
   * Overview = Gets created on game create
   * 1 = Details
   * 2 = Media
   * 3 = Extras
   * 4 = Critique
   * 5 = Practical
   * Buy = Gets created on game create
   * Recommended = Gets created on game create
   */
  public type: number;

  constructor(values: Object = {}) {
    Object.assign(this, values);
  }
}

export class Game {
  //#region practical
  public id: number;
  public title: string;
  public coverPictureUrl: string;
  public gameSummary: string;
  // public summary: string; - Summary is created from other properties
  public price: number;
  public priceValuta: string;
  public salesPrice: number;
  public releaseDate: Date;
  public languages: string[];
  public multiplayer: string;
  public vrSupport: string;
  public ageRating: number;
  public faq: string[];
  public systemRequirements: string;
  public hardwareSupport: string;
  public externalLinks: string[]; // For links of interest e.g. reddit page, twitch page, news, etc.
  public publisher: any;
  public developer: any;
  public platforms: any[];
  public regions: any[];
  public genres: any[];
  public tags: any[];
  //#endregion

  //#region lore
  public history: string;
  public world: string;
  public features: string;
  public characters: any[];
  public enemies: any[];
  public mechanics: any[];
  //#endregion

  //#region media
  public videos: any[];
  public pictures: any[];
  public news: any[];
  //#endregion

  //#region editions
  public editions: any[];
  public dlcs: string;
  public bundles: string;
  //#endregion

  //#region critique
  public officialReviews: string[];
  public youtubeReviews: string[];
  public buyerReviews: string[];
  public twitchStreams: string[];
  public pros: string[];
  public cons: string[];
  public metacriticTag: string;
  //#endregion

  constructor(values: Object = {}) {
    Object.assign(this, values);
  }
}
