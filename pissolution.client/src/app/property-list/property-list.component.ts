import { Component, OnInit } from '@angular/core';
import { PropertyService, Property } from '../property.service';

@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.css']
})
export class PropertyListComponent implements OnInit {
  properties: Property[] = [];
  totalCount: number = 0;
  pageIndex: number = 1;
  pageSize: number = 10;
  search: string = '';

  constructor(private propertyService: PropertyService) { }

  ngOnInit(): void {
    this.loadProperties();
  }

  loadProperties(): void {
    this.propertyService.getProperties(this.pageIndex, this.pageSize, this.search).subscribe(response => {
      this.properties = response;
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
}
