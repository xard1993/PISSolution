import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '../environments/environment.development';
import { Property } from './model/property';
import { Ownership } from './model/ownership';
import { PriceHistory } from './model/pricehistory';


@Injectable({
  providedIn: 'root'
})
export class PropertyService {
  private apiUrl = `${environment.apiUrl}/property`;

  constructor(private http: HttpClient) { }

  getProperties(pageIndex: number, pageSize: number, search: string): Observable<{ items: Property[], totalCount: number }> {
    let params = new HttpParams()
      .set('pageIndex', pageIndex.toString())
      .set('pageSize', pageSize.toString())
      .set('search', search);

    return this.http.get<{ items: Property[], totalCount: number }>(this.apiUrl, { params })
      .pipe(
        map(response => {         
          if (Array.isArray(response.items)) {
            return {

              items: response.items.map(item => this.mapProperty(item)),
              totalCount: response.totalCount
            };
          } else {
            throw new Error('Expected an array of items' + response.items);
          }
        })
      );
  }

  getProperty(id: string): Observable<Property> {
    return this.http.get<any>(`${this.apiUrl}/${id}`)
      .pipe(
        map(this.mapProperty)
      );
  }

  createProperty(property: Property): Observable<Property> {
    return this.http.post<Property>(this.apiUrl, property);
  }

  updateProperty(id: string, property: Property): Observable<Property> {
    return this.http.put<Property>(`${this.apiUrl}/`, property);
  }

  deleteProperty(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  private mapProperty(item: any): Property {
    return {
      id: item.id,
      propertyName: item.propertyName,
      address: item.address,
      price: item.price,
      dateOfRegistration: new Date(item.dateOfRegistration),
      ownerships: item.ownerships.$values.length != 0 ? item.ownerships.$values.map((ownership: Ownership) => ({
        id: ownership.id,
        contactID: ownership.contactID,
        propertyID: ownership.propertyID,
        effectiveFrom: new Date(ownership.effectiveFrom),
        effectiveTill: new Date(ownership.effectiveTill),
        acquisitionPrice: ownership.acquisitionPrice,
        contact: ownership.contact ? {
          id: ownership.contact.id,
          firstName: ownership.contact.firstName,
          lastName: ownership.contact.lastName,
          phoneNumber: ownership.contact.phoneNumber,
          email: ownership.contact.email
        } : null
      })) : [],
      priceHistories: item.priceHistories.$values.length != 0 ? item.priceHistories.$values.map((history: PriceHistory) => ({
        id: history.id,
        propertyID: history.propertyID,
        price: history.price,
        date: new Date(history.date)
      })) : []
    };
  }
}
