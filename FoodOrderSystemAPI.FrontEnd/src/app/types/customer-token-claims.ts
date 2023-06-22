import { Time } from "@angular/common";

export class CustomerTokenClaims {
    constructor(public id : number , public UserName : string , public Role :string , public Email:string , public TokenExpirationDate :Date){}
}
