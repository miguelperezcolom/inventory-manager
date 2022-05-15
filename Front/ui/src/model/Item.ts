export class Item {
  name: string;
  type: string;
  expirationDate: string;

  constructor(name: string, type: string, expirationDate: string) {
    this.name = name;
    this.type = type;
    this.expirationDate = expirationDate;
  }
}
