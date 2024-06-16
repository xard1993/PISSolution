import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { Contact } from '../../model/contact';
import { environment } from '../../../environments/environment.development';


@Injectable({
  providedIn: 'root'
})
export class ContactService {
  private apiUrl = `${environment.apiUrl}/contact`;

  constructor(private http: HttpClient) { }

  //consumes api to load all contacts
  getContacts(pageIndex: number, pageSize: number, search: string): Observable<{ items: Contact[], totalCount: number }> {
    let params = new HttpParams()
      .set('pageIndex', pageIndex.toString())
      .set('pageSize', pageSize.toString())
      .set('search', search);

    return this.http.get<{ items: Contact[], totalCount: number }>(this.apiUrl, { params })
      .pipe(
        map(response => {
          if (Array.isArray(response.items)) {
            return {

              items: response.items.map(item => this.mapContact(item)),
              totalCount: response.totalCount
            };
          } else {
            throw new Error('Expected an array of items' + response.items);
          }
        })
      );
  }

  //get 1 contact by id
  getContact(id: string): Observable<Contact> {
    return this.http.get<Contact>(`${this.apiUrl}/${id}`);
  }

  // post contact
  createContact(contact: Contact): Observable<Contact> {
    return this.http.post<Contact>(`${this.apiUrl}`, contact);
  }
  // put contact
  updateContact(contact: Contact): Observable<Contact> {
    return this.http.put<Contact>(`${this.apiUrl}`, contact);
  }

  //maps api info to contact model
  private mapContact(item: any): Contact {
    return {
      id: item.id,
      firstName: item.firstName,
      lastName: item.lastName,
      phoneNumber: item.phoneNumber,
      email: item.email
        
    };
  }

}
