import { Component, OnInit } from '@angular/core';
import { PropertyService } from '../property.service';
import { Property } from '../model/property';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.css']
})
export class PropertyListComponent implements OnInit {
  properties: Property[] = [];
  selectedProperty: Property | null = null;
  totalCount: number = 0;
  pageIndex: number = 1;
  pageSize: number = 10;
  search: string = '';

  constructor(private propertyService: PropertyService, private router: Router) { }

  ngOnInit(): void {
    this.loadProperties();
  }

  loadProperties(): void {
    this.propertyService.getProperties(this.pageIndex, this.pageSize, this.search).subscribe(response => {
      this.properties = response.items;
      this.totalCount = response.totalCount;

    });
  }

  onSearch(): void {
    this.pageIndex = 1; // Reset to first page on new search
    this.loadProperties();
  }

  onPageChange(newPage: number): void {
    this.pageIndex = newPage;
    this.loadProperties();
  }
 
  editProperty(property: Property): void {
    this.router.navigate(['/properties/edit', property.id]);
  }

  selectProperty(property: Property): void {
    if (this.selectedProperty && this.selectedProperty.id === property.id) {
      this.selectedProperty = null; // Deselect if already selected
    } else {
      this.propertyService.getProperty(property.id).subscribe(fullProperty => {
        this.selectedProperty = fullProperty;
      });
    }
  }
}

