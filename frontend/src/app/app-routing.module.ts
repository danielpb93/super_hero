import { SuperHeroSearchComponent } from './super-hero/super-hero-search/super-hero-search.component';
import { SuperHeroListComponent } from './super-hero/super-hero-list/super-hero-list.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'herolist',
    pathMatch: 'full',
  },
  {
    path: 'herolist',
    component: SuperHeroListComponent,
  },
  {
    path: 'herosearch',
    component: SuperHeroSearchComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
