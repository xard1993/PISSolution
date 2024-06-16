import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgxPaginationModule } from 'ngx-pagination';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContactListComponent } from './component/contact/contact-list/contact-list.component';
import { ContactCreateComponent } from './component/contact/contact-create/contact-create.component';
import { ContactEditComponent } from './component/contact/contact-edit/contact-edit.component';
import { PropertyListComponent } from './component/property/property-list/property-list.component';
import { PropertyEditComponent } from './component/property/property-edit/property-edit.component';
import { PropertyCreateComponent } from './component/property/property-create/property-create.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MenuComponent } from './component/menu/menu.component';

@NgModule({
  declarations: [
    AppComponent,
    ContactListComponent,
    ContactCreateComponent,
    ContactEditComponent,
    PropertyListComponent,
    PropertyCreateComponent,
    PropertyEditComponent,
    MenuComponent,

  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    NgxPaginationModule,
    AppRoutingModule,
    ReactiveFormsModule,
     MatToolbarModule,
    MatButtonModule,
    MatMenuModule
  ],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
