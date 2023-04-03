
export class Vault {
    constructor(data) {
        this.id = data.id
        this.creatorId = data.creatorId
        this.creator = data.creator
        this.description = data.description
        this.name = data.name
        this.img = data.img
        this.isPrivate = data.isPrivate
    }
}