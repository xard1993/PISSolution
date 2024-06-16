import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PropertyService } from '../property.service';
import { Property } from '../../../model/property';
import { Ownership } from '../../../model/ownership';


@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.css']
})
export class PropertyListComponent implements OnInit {
  properties: Property[] = [];
  latestOwnerships: { [propertyId: string]: Ownership | null } = {};
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
      this.calculateLatestOwnerships();
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

 
  convertToUSD(amount: number | null): string {
    if (amount === null || amount === undefined) {
      return '';
    }
    amount = amount * 1.07;
    return new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' }).format(amount);
  }
  convertToEUR(amount: number | null): string {
    if (amount === null || amount === undefined) {
      return '';
    }
    
    return new Intl.NumberFormat('en-US', { style: 'currency', currency: 'EUR' }).format(amount);
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

  calculateLatestOwnerships(): void {
    this.properties.forEach(property => {  
      this.latestOwnerships[property.id] = this.getLatestOwnership(property);
    });
  }
  getLatestOwnership(property: Property): Ownership | null {
    console.log(property.id);

    if (!property.ownerships || property.ownerships.length === 0) {
      return null;
    }

    return property.ownerships.reduce((latest, current) => {
      return new Date(latest.effectiveFrom) > new Date(current.effectiveFrom) ? latest : current;

    });
  }
  getOwnershipDetails(ownership: Ownership | null): string {
    return ownership ? `${ownership.contact.firstName} ${ownership.contact.lastName}` : 'No owner';
  }
}

