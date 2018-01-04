export class Game {
    public id: number;
    public title: string;
    public shortDescription: string;
    public description: string;
    public price: number;
    public release: Date;
    public picture: File;
    public pictureId: number;

    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}
