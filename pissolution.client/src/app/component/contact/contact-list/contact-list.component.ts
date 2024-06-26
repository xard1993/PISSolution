import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Contact } from '../../../model/contact';
import { ContactService } from '../contact.service';


@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContactListComponent implements OnInit {
  contacts: Contact[] = []; 
  totalCount: number = 0;
  pageIndex: number = 1;
  pageSize: number = 10;
  search: string = '';
  constructor(private contactService: ContactService, private router: Router) { }

  ngOnInit(): void {
    this.loadContacts();
  }

  //loads contacts into contact component
  loadContacts(): void {
    this.contactService.getContacts(this.pageIndex, this.pageSize, this.search).subscribe(response => {
      this.contacts = response.items;
      this.totalCount = response.totalCount;
    });
  }
  //Search method
  onSearch(): void {
    this.pageIndex = 1; // Reset to first page on new search
    this.loadContacts();
  }
  //pager on change method
  onPageChange(newPage: number): void {
    this.pageIndex = newPage;
    this.loadContacts();
  }
  //route comp to edit component using id as param
  editContact(contact: Contact): void {
    this.router.navigate(['/contacts/edit', contact.id]);
  }
}
