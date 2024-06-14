import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment.development';

export interface Ownership {
  id: string;
  contactID: string;
  propertyID: string;
  effectiveFrom: Date;
  effectiveTill: Date;
  acquisitionPrice: number;
}

export interface PriceHistory {
  id: string;
  propertyID: string;
  price: number;
  dateChanged: Date;
}

export interface Property {
  id: string;
  propertyName: string;
  address: string;
  price: number;
  dateOfRegistration: Date;
  ownerships?: Ownership[];
  priceHistories?: PriceHistory[];
}

@Injectable({
  providedIn: 'root'
})
export class PropertyService {
  private apiUrl = `${environment.apiUrl}/property`;

  constructor(private http: HttpClient) { }

  getProperties(pageIndex: number, pageSize: number, search: string): Observable<any> {
    const params = { pageIndex: pageIndex.toString(), pageSize: pageSize.toString(), search };
    return this.http.get<any>(this.apiUrl, { params });
  }

  getProperty(id: string): Observable<Property> {
    return this.http.get<Property>(`${this.apiUrl}/${id}`);
  }

  createProperty(property: Property): Observable<Property> {
    return this.http.post<Property>(this.apiUrl, property);
  }

  updateProperty(id: string, property: Property): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, property);
  }

  deleteProperty(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
