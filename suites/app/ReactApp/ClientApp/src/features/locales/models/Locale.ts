import { LocaleType } from "../types/LocaleType"

export class Locale{

    private type: LocaleType

    constructor(text: string){
        switch (text) {
            case LocaleType.US:
                this.type = LocaleType.US
            case LocaleType.JP:
                this.type = LocaleType.JP
            default:
                this.type = LocaleType.US
        }
    }

    public getLocaleType(){
        return this.type
    }
}