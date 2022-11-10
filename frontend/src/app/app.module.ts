import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './layout/header/header.component';
import { FooterComponent } from './layout/footer/footer.component';
import { SuperHeroListComponent } from './super-hero/super-hero-list/super-hero-list.component';
import { SuperHeroFormComponent } from './super-hero/super-hero-form/super-hero-form.component';

import { HttpClientModule } from '@angular/common/http';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { DynamicDialogModule } from 'primeng/dynamicdialog';
import { InputTextModule } from 'primeng/inputtext';
import { MultiSelectModule } from 'primeng/multiselect';
import { ReactiveFormsModule } from '@angular/forms';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService } from 'primeng/api';
import { SuperHeroSearchComponent } from './super-hero/super-hero-search/super-hero-search.component';
import { InputNumberModule } from 'primeng/inputnumber';
import { CardModule } from 'primeng/card';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    SuperHeroListComponent,
    SuperHeroFormComponent,
    SuperHeroSearchComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    TableModule,
    ButtonModule,
    DynamicDialogModule,
    InputTextModule,
    MultiSelectModule,
    ReactiveFormsModule,
    ToastModule,
    ConfirmDialogModule,
    InputNumberModule,
    CardModule,
  ],
  providers: [MessageService, ConfirmationService],
  bootstrap: [AppComponent],
})
export class AppModule {}
