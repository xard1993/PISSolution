import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PropertyListComponent } from './property-list/property-list.component';
import { PropertyCreateComponent } from './property-create/property-create.component';
import { PropertyEditComponent } from './property-edit/property-edit.component';

const routes: Routes = [
  { path: '', redirectTo: '/properties', pathMatch: 'full' },
  { path: 'properties', component: PropertyListComponent },
  { path: 'properties/create', component: PropertyCreateComponent },
  { path: 'properties/edit/:id', component: PropertyEditComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
