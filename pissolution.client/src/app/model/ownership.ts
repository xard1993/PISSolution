import { Contact } from "./contact";

export interface Ownership {
  id: string;
  contactID: string;
  propertyID: string;
  effectiveFrom: Date;
  effectiveTill: Date;
  acquisitionPrice: number;
  contact: Contact;
}

