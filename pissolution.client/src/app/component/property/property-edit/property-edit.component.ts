import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PropertyService } from '../property.service';




@Component({
  selector: 'app-property-edit',
  templateUrl: './property-edit.component.html',
  styleUrls: ['./property-edit.component.css']
})
export class PropertyEditComponent implements OnInit {
  propertyForm: FormGroup;
  propertyId: string;

  constructor(
    private fb: FormBuilder,
    private propertyService: PropertyService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.propertyForm = this.fb.group({
      id: [''],
      propertyName: ['', Validators.required],
      address: ['', Validators.required],
      price: [0, [Validators.required, Validators.min(1)]],
      dateOfRegistration: ['', Validators.required]
    });
    this.propertyId = this.route.snapshot.paramMap.get('id')!;
  }

  ngOnInit(): void {
    this.loadProperty();
  }

  loadProperty(): void {
    this.propertyService.getProperty(this.propertyId).subscribe(property => {
      this.propertyForm.patchValue(property);
    });
  }

  onSubmit(): void {
    if (this.propertyForm.valid) {
      this.propertyService.updateProperty(this.propertyId, this.propertyForm.value).subscribe(response => {
        this.router.navigate(['/properties']); // Navigate to the property list page
      }, error => {
        console.error('Error updating property:', error);
      });
    }
  }
}
