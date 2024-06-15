import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PropertyListComponent } from './component/property/property-list/property-list.component';
import { PropertyCreateComponent } from './component/property/property-create/property-create.component';
import { PropertyEditComponent } from './component/property/property-edit/property-edit.component';
import { ContactListComponent } from './component/contact/contact-list/contact-list.component';
import { ContactEditComponent } from './component/contact/contact-edit/contact-edit.component';
import { ContactCreateComponent } from './component/contact/contact-create/contact-create.component';

const routes: Routes = [
  { path: '', redirectTo: '/properties', pathMatch: 'full' },
  { path: 'properties', component: PropertyListComponent },
  { path: 'properties/create', component: PropertyCreateComponent },
  { path: 'properties/edit/:id', component: PropertyEditComponent },
  { path: 'contacts', component: ContactListComponent },
  { path: 'contacts/edit/:id', component: ContactEditComponent },
  { path: 'contacts/create', component: ContactCreateComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
