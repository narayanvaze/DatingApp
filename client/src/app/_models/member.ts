import { Photo } from "./photo"

export interface Member{
    id: number
    userName: string
    passwordHash: string
    passwordSalt: string
    age: number
    knownAs: any
    created: string
    lastActive: string
    gender: any
    photoUrl: any
    introduction: any
    lookingFor: any
    interests: any
    city: any
    country: any
    photos: Photo[]
}
