import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'; 
import { HttpClientModule } from '@angular/common/http';
import { NgxPaginationModule } from 'ngx-pagination';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContactListComponent } from './contact-list/contact-list.component';
import { ContactCreateComponent } from './contact-create/contact-create.component';
import { ContactEditComponent } from './contact-edit/contact-edit.component';
import { ContactDeleteComponent } from './contact-delete/contact-delete.component';
import { PropertyListComponent } from './property-list/property-list.component';
import { PropertyCreateComponent } from './property-create/property-create.component';
import { PropertyEditComponent } from './property-edit/property-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    ContactListComponent,
    ContactCreateComponent,
    ContactEditComponent,
    ContactDeleteComponent,
    PropertyListComponent,
    PropertyCreateComponent,
    PropertyEditComponent,

  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    NgxPaginationModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
