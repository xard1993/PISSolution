import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PropertyService } from '../property.service';



@Component({
  selector: 'app-property-create',
  templateUrl: './property-create.component.html',
  styleUrls: ['./property-create.component.css']
})
export class PropertyCreateComponent implements OnInit {
  propertyForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private propertyService: PropertyService,
    private router: Router
  ) {
    this.propertyForm = this.fb.group({
      propertyName: ['', Validators.required],
      address: ['', Validators.required],
      price: [0, [Validators.required, Validators.min(1)]],
      dateOfRegistration: ['', Validators.required],
      ownerships: this.fb.array([]),
      priceHistories: this.fb.array([])
    });
  }

  ngOnInit(): void {

  }

  get ownerships(): FormArray {
    return this.propertyForm.get('ownerships') as FormArray;
  }



  
  onSubmit(): void {
    if (this.propertyForm.valid) {
      this.propertyService.createProperty(this.propertyForm.value).subscribe(response => {
        this.router.navigate(['/properties']);
      }, error => {
        console.error('Error creating property:', error);
      });
    }
  }
}

