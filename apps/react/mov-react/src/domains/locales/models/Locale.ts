import { LocaleType } from "../types/LocaleType";

export class Locale {
  private type: LocaleType;

  constructor(text: string);
  constructor(type: LocaleType);
  constructor(localeType: LocaleType | string) {
    if (typeof localeType === "string") {
      switch (localeType) {
        case LocaleType.US:
          this.type = LocaleType.US;
        case LocaleType.JP:
          this.type = LocaleType.JP;
        default:
          this.type = LocaleType.US;
      }
    } else {
      this.type = localeType;
    }
  }

  public toLocaleType(): LocaleType {
    return this.type;
  }

  public toLocaleString(): string {
    return this.type.toString();
  }
}
