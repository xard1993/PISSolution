import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ContactService } from '../contact.service';



@Component({
  selector: 'app-contact-edit',
  templateUrl: './contact-edit.component.html',
  styleUrls: ['./contact-edit.component.css']
})
export class ContactEditComponent implements OnInit {
  contactForm: FormGroup;
  contactId: string;

  constructor(
    private fb: FormBuilder,
    private contactService: ContactService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.contactForm = this.fb.group({
      id: [''],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });
    this.contactId = this.route.snapshot.paramMap.get('id')!;
  }

  ngOnInit(): void {
    this.loadContact();
  }

  //loading contact for edit
  loadContact(): void {
    this.contactService.getContact(this.contactId).subscribe(contact => {
      this.contactForm.patchValue(contact);
    });
  }
  //on cubmit navigate to contact list page
  onSubmit(): void {
    if (this.contactForm.valid) {
      this.contactService.updateContact(this.contactForm.value).subscribe(response => {
        this.router.navigate(['/contacts']); // Navigate to the contact list page
      }, error => {
        console.error('Error updating contact:', error);
      });
    }
  }
}
