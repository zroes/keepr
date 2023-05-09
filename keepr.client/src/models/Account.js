export class Profile {
  constructor(data) {
    this.id = data.id
    this.name = data.name
    this.picture = data.picture
    this.coverImg = data.coverImg
  }
}



export class Account {
  constructor(data) {
    this.email = data.email
    this.id = data.id
    this.name = data.name
    this.picture = data.picture
    // TODO add additional properties if needed
  }
}
