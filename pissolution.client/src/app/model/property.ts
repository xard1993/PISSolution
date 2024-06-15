import { PriceHistory } from "./pricehistory";
import { Ownership } from "./ownership";

export interface Property {
  id: string;
  propertyName: string;
  address: string;
  price: number;
  dateOfRegistration: Date;
  ownerships?: Ownership[];
  priceHistories?: PriceHistory[];
}
