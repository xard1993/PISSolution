import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgxPaginationModule } from 'ngx-pagination';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContactListComponent } from './component/contact/contact-list/contact-list.component';
import { ContactCreateComponent } from './component/contact/contact-create/contact-create.component';
import { ContactEditComponent } from './component/contact/contact-edit/contact-edit.component';
import { PropertyListComponent } from './component/property/property-list/property-list.component';
import { PropertyEditComponent } from './component/property/property-edit/property-edit.component';
import { PropertyCreateComponent } from './component/property/property-create/property-create.component';

@NgModule({
  declarations: [
    AppComponent,
    ContactListComponent,
    ContactCreateComponent,
    ContactEditComponent,
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
