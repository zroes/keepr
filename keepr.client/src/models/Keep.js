export class Keep {
  constructor(data) {
    this.creator = data.creator
    this.creatorId = data.creatorId
    this.description = data.description
    this.id = data.id
    this.imgUrl = data.img
    this.keptCount = data.kept
    this.name = data.name
    this.views = data.views
    this.vaultKeepId = data.vaultKeepId || null
  }
}

// export class VaultKeep extends Keep {
//   constructor(data) {
//     this.vaultKeepId = data.vaultKeepId
//   }
// }